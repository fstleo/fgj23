using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class RootDirectionHandle : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private bool _isDragging;
    
    [SerializeField]
    private Root _root;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDragging = true;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (_isDragging)
        {
            _root.SetDirection(eventData.delta);
        }

        _isDragging = false;
    }


}