using UnityEngine;

public class RootEnd : MonoBehaviour
{
    [SerializeField] private Root _root;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.position = _root.EndPosition;
    }
}