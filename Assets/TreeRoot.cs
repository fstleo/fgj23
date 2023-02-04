using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TreeRoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _rootPrefab;

    private List<Root> _roots = new List<Root>();

    [SerializeField]
    private float _timeBeforeBranchOut;
    
    [SerializeField]
    [Range(0, 100)]
    private int _chanceToBranchTwoAtOnce;
    

    private float _branchOutTimer;
    private void Awake()
    {
        BranchOut(_rootPrefab.GetComponent<Root>(), transform.position);
    }

    private void BranchOutFromRandomRoot()
    {
        var spawnTwo = Random.Range(0, 100) > 100 - _chanceToBranchTwoAtOnce;
        for (int i = 0; i < (spawnTwo ? 2 : 1); i++)
        {
            var branchingRoot = _roots[Random.Range(0, _roots.Count)];
            BranchOut(branchingRoot, branchingRoot.EndPosition);    
        }
        
    }

    private void BranchOut(Root root, Vector3 position)
    {
        var branch = Instantiate(_rootPrefab, position, Quaternion.identity).GetComponent<Root>();
        branch.SetDirection(root.Direction);
        _roots.Add(branch);
    }


    private void Update()
    {
        _branchOutTimer += Time.deltaTime;
        if (_branchOutTimer > _timeBeforeBranchOut)
        {
            BranchOutFromRandomRoot();
            _branchOutTimer = 0;
        }
    }
}