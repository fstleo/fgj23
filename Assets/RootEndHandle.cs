using UnityEngine;
using UnityEngine.EventSystems;

public class RootEndHandle : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    
    private bool _isDragging;
    
    [SerializeField]
    private Root _root;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.localPosition = _root.EndPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDragging = true;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (_isDragging)
        {
            _root.SetDirection(eventData.delta.normalized);
        }

        _isDragging = false;
    }


}