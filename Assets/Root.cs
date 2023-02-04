using UnityEngine;

public class Root : MonoBehaviour
{

    [SerializeField]
    private LineRenderer _rootLine;
    
    [SerializeField]
    private float _growSpeed;

    [SerializeField]
    private float _growAngle;

    private Vector3 _direction = Vector3.down;

    public void Update()
    {
        var lastPosition = _rootLine.GetPosition(_rootLine.positionCount - 1);
        var lastIndex = _rootLine.positionCount - 1;
        _rootLine.SetPosition(lastIndex, lastPosition + _growSpeed * _direction * Time.deltaTime);
        if ((_rootLine.GetPosition(lastIndex) - _rootLine.GetPosition(lastIndex - 1)).sqrMagnitude > 4)
        {
            _rootLine.positionCount ++;
            _rootLine.SetPosition(lastIndex + 1, _rootLine.GetPosition(lastIndex));
            _direction = Quaternion.Euler(0, 0, Random.Range(-_growAngle, _growAngle)) * Vector3.down; 
        }
    }
}
