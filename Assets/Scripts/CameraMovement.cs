using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] 
    private float _maxY;

    [SerializeField] private Camera _camera;
    
    private Transform _cameraTransform;

    [SerializeField]
    private float _mouseSensitivity;
    
    [SerializeField]
    private float _zoomSensitivity;
    
    private Vector3 _delta;
    private Vector3 _startDragPosition;
    
    public static bool Locked { get; set; }

    private Game _gameInstance;

    private void Awake()
    {
        Locked = false;
        _cameraTransform = transform;
    }

    private void Update()
    {
        if (Locked)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            _startDragPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            _delta = Input.mousePosition - _startDragPosition;
            var position = _cameraTransform.position;
            position = new Vector3(
                position.x - _delta.x * _mouseSensitivity,
                Mathf.Min(position.y - _delta.y * _mouseSensitivity, _maxY),
                position.z);
            _cameraTransform.position = position;
            _startDragPosition = Input.mousePosition;
        }
        
        _camera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * _zoomSensitivity;

    }

    public void Init(Game gameInstance)
    {
        gameInstance.GameStateChange += GameStateChange;
        _gameInstance = gameInstance;
    }

    private void OnDestroy()
    {
        _gameInstance.GameStateChange -= GameStateChange;
    }

    private void GameStateChange(GameState state)
    {
        Locked = state != GameState.Game;
        if (state == GameState.GameOver)
        {
            _cameraTransform.position = new Vector3(0, 0, _cameraTransform.position.z);
        }
    }
}