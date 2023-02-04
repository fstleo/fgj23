using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class RootDirectionHandle : MonoBehaviour, IDragHandler, IBeginDragHandler,
    IPointerDownHandler,
    IEndDragHandler
{
    private bool _isDragging;
    
    [SerializeField]
    private Root _root;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        CameraMovement.Locked = true;
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


    public void OnEndDrag(PointerEventData eventData)
    {
        CameraMovement.Locked = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CameraMovement.Locked = true;
    }
}