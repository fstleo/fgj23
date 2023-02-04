using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] 
    private float _maxY;
    
    [SerializeField]
    private Transform _cameraTransform;

    private Vector3 _delta;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag: " + eventData.pointerPressRaycast.screenPosition);

        // Obtain the position of the hit GameObject.
        _delta = eventData.pointerPressRaycast.worldPosition;
        _delta = _delta - transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var newPosition = eventData.pointerCurrentRaycast.worldPosition - _delta;

        if (eventData.pointerCurrentRaycast.worldPosition.x == 0.0f ||
            eventData.pointerCurrentRaycast.worldPosition.y == 0.0f)
        {
            newPosition = eventData.delta;

            _cameraTransform.Translate(newPosition * Time.deltaTime);
            return;
        }

        _cameraTransform.position = newPosition;
    }

}