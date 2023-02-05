using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreeRoot : MonoBehaviour
{
    public event Action Deadge;
    
    [SerializeField]
    private GameObject _rootPrefab;

    [SerializeField]
    private float _timeToCreateDecorativeBranch;
    
    [SerializeField]
    private float _timeBeforeBranchOut;
    
    [SerializeField]
    [Range(0, 100)]
    private int _chanceToBranchTwoAtOnce;

    private bool _treeDeadge;
    
    private readonly List<Root> _activeRoots = new List<Root>();

    private float _branchOutTimer;
    private float _decorationTimer;
    
    private static int _activeRootsCount;

    public static int ActiveRoots
    {
        get => _activeRootsCount;
        private set
        {
            if (_activeRootsCount > MaximumActiveRoots)
            {
                MaximumActiveRoots = _activeRootsCount;
            }
            _activeRootsCount = value;
        }
    }

    public static int MaximumActiveRoots { get; private set; }

    private void Awake()
    {
        BranchOut(Instantiate(_rootPrefab).GetComponent<Root>(), transform.position);
    }

    private void BranchOutFromRandomRoot()
    {
        var spawnTwo = Random.Range(0, 100) > 100 - _chanceToBranchTwoAtOnce;
        for (int i = 0; i < (spawnTwo ? 2 : 1); i++)
        {
            var branchingRoot = _activeRoots[Random.Range(0, _activeRoots.Count)];
            BranchOut(branchingRoot, branchingRoot.EndPosition);    
            BranchOut(branchingRoot, branchingRoot.EndPosition);    
        }
    }

    private void BranchOut(Root root, Vector3 position, bool decorative = false)
    {
        var branch = Instantiate(_rootPrefab, position, Quaternion.identity).GetComponent<Root>();
        branch.SetDirection(Quaternion.Euler(0,0,Random.Range(-1f, 1f) * Random.Range(60,120)) * root.Direction);
        if (decorative)  
        {
            branch.Deactivate();
            branch.SetDecorative();
            root.AttachDecoration(branch);
        }
        else
        {
            root.Attach(branch);
            branch.Deadge += () =>
            {
                _activeRoots.Remove(branch);
                ActiveRoots = _activeRoots.Count;
            };
            _activeRoots.Add(branch);
            
            root.Deactivate();
            _activeRoots.Remove(root);
            ActiveRoots = _activeRoots.Count;
        }
        
    }

    private void BranchOutDecorative()
    {
        foreach (var root in _activeRoots)
        {
            BranchOut(root, root.EndPosition, true);    
        }
        
    }

    private void Update()
    {
        if (_treeDeadge)
        {
            return;
        }
        
        if (_activeRoots.Count < TreePicture.RootsNeeded)
        {
            _treeDeadge = true;
            Deadge?.Invoke();
        }
        
        _branchOutTimer += Time.deltaTime;
        _decorationTimer += Time.deltaTime;
        if (_decorationTimer > _timeToCreateDecorativeBranch)
        {
            BranchOutDecorative();
            _decorationTimer = 0;
        }
        if (_branchOutTimer > _timeBeforeBranchOut)
        {
            BranchOutFromRandomRoot();
            _branchOutTimer = 0;
        }
    }
}