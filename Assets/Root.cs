using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Root : MonoBehaviour, IDragHandler, IBeginDragHandler
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
    private MeshCollider _meshCollider;

    [SerializeField]
    private float _directionChange;
    
    private Vector3 _direction = Vector3.down;
    private bool _isDragging;

    public void Update()
    {
        GrowRoot();
        BakeCollision();
    }
    
    private void BakeCollision()
    {
        var mesh = new Mesh();
        _rootLine.BakeMesh(mesh);
        _meshCollider.sharedMesh = mesh;
    }

    private void GrowRoot()
    {
        var lastPosition = _rootLine.GetPosition(_rootLine.positionCount - 1);
        var lastIndex = _rootLine.positionCount - 1;
        _rootLine.SetPosition(lastIndex, lastPosition + _growSpeed * _direction * Time.deltaTime);

        if ((_rootLine.GetPosition(lastIndex) - _rootLine.GetPosition(lastIndex - 1)).sqrMagnitude >
            _lengthBeforeTurn * _lengthBeforeTurn)
        {
            Turn(lastIndex);
        }
    }

    private void Turn(int lastIndex)
    {
        _rootLine.positionCount++;
        _rootLine.SetPosition(lastIndex + 1, _rootLine.GetPosition(lastIndex));
        _direction = Quaternion.Euler(0, 0, Random.Range(-_growTurnAngle, _growTurnAngle)) * _direction;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDragging = true;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (_isDragging)
            _direction = eventData.delta.normalized;
        _isDragging = false;
    }
    

}

