using UnityEngine;
using Random = UnityEngine.Random;

public class RandomRotation : MonoBehaviour
{
    
    [SerializeField]
    private bool _lockX;
 
    [SerializeField]
    private float _minX = -180;
    
    [SerializeField]
    private float _maxX = 180;
    
    
    [SerializeField]
    private bool _lockY;
    [SerializeField]
    private float _minY = -180;
    
    [SerializeField]
    private float _maxY = 180;


    [SerializeField]
    private bool _lockZ;
    [SerializeField]
    private float _minZ = -180;
    
    [SerializeField]
    private float _maxZ = 180;
    
    private void Awake()
    {
        transform.rotation = Quaternion.Euler(
            _lockX ? transform.rotation.eulerAngles.x : Random.Range(_minX, _maxX),
            _lockY ? transform.rotation.eulerAngles.y : Random.Range(_minY, _maxY),
            _lockZ ? transform.rotation.eulerAngles.z : Random.Range(_minZ, _maxZ));
    }

}
