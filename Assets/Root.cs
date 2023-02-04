using UnityEngine;
using UnityEngine.Serialization;

public class Root : MonoBehaviour
{

    [SerializeField]
    private LineRenderer _rootLine;
    
    [SerializeField]
    private float _growSpeed;

    [FormerlySerializedAs("_growAngle")] [SerializeField]
    private float _growTurnAngle;
    
    [SerializeField]
    private float _lengthBeforeTurn;


    private Vector3 _direction = Vector3.down;

    public void Update()
    {
        var lastPosition = _rootLine.GetPosition(_rootLine.positionCount - 1);
        var lastIndex = _rootLine.positionCount - 1;
        _rootLine.SetPosition(lastIndex, lastPosition + _growSpeed * _direction * Time.deltaTime);
        if ((_rootLine.GetPosition(lastIndex) - _rootLine.GetPosition(lastIndex - 1)).sqrMagnitude > _lengthBeforeTurn * _lengthBeforeTurn)
        {
            _rootLine.positionCount ++;
            _rootLine.SetPosition(lastIndex + 1, _rootLine.GetPosition(lastIndex));
            _direction = Quaternion.Euler(0, 0, Random.Range(-_growTurnAngle, _growTurnAngle)) * Vector3.down; 
        }
    }
}
