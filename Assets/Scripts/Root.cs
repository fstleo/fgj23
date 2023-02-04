using UnityEngine;
using Random = UnityEngine.Random;

public class Root : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _rootLine;
    
    [SerializeField]
    private float _growSpeed;

    [SerializeField]
    private float _growTurnAngle;
    
    [SerializeField]
    private float _lengthBeforeTurn;

    [SerializeField]
    private float _maximumDecorativeRootLength;

    [SerializeField]
    private float _maxYBeforeForceTurnDown;
    
    public Vector3 Direction { get; private set; } = Vector3.down;

    private float _nextSegmentLength;
    private float _length;
    private bool _isDecorative;

    public Vector3 EndPosition => transform.position + _rootLine.GetPosition(_rootLine.positionCount - 1);

    private void Awake()
    {
        _nextSegmentLength = _lengthBeforeTurn;
    }

    public void SetDecorative()
    {
        _isDecorative = true;
        for (int i = transform.childCount - 1; i >=0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void Update()
    {
        if (_isDecorative && _length > _maximumDecorativeRootLength)
        {
            return;
        }
        
        GrowRoot();
        AdjustLineThickness();
    }

    private void AdjustLineThickness()
    {
        var positionCount = _rootLine.positionCount;
        var widthCurve = _rootLine.widthCurve;
        widthCurve.MoveKey(1, new Keyframe
        {
            time = 1f * (positionCount - 1) / positionCount,
            value = 1f
        });
        _rootLine.widthCurve = widthCurve;
    }
    
    private void GrowRoot()
    {
        var lastPosition = _rootLine.GetPosition(_rootLine.positionCount - 1);
        var lastIndex = _rootLine.positionCount - 1;
        var increase = _growSpeed * Time.deltaTime;
        _rootLine.SetPosition(lastIndex, lastPosition + increase * Direction);
        _length += increase;
        TurnDownIfCloseToTheSurface(lastIndex);

        if ((_rootLine.GetPosition(lastIndex) - _rootLine.GetPosition(lastIndex - 1)).sqrMagnitude >
            _nextSegmentLength * _nextSegmentLength)
        {
            RandomTurn(lastIndex);
        }
    }

    private void TurnDownIfCloseToTheSurface(int lastIndex)
    {
        if (_rootLine.GetPosition(lastIndex).y > _maxYBeforeForceTurnDown)
        {
            var angle = Vector3.SignedAngle(Vector3.down, Direction, Vector3.forward);
            if (Mathf.Abs(angle) > 90)
            {
                Direction = Quaternion.Euler(0, 0, -Mathf.Sign(angle) * 45) * Direction;
            }
        }
    }

    private void RandomTurn(int lastIndex)
    {
        _rootLine.positionCount++;
        _rootLine.SetPosition(lastIndex + 1, _rootLine.GetPosition(lastIndex));
        Direction = Quaternion.Euler(0, 0, Random.Range(-_growTurnAngle, _growTurnAngle)) * Direction;
        _nextSegmentLength = Random.Range(_lengthBeforeTurn / 2, _lengthBeforeTurn);
    }
    
    public void SetDirection(Vector3 direction)
    {
        Direction = direction.normalized;
    }
}

