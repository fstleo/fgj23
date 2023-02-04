using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Collectible : MonoBehaviour
{
    public event Action<Collectible> Collected;

    public UnityEvent CollectedEffects;
    
    [SerializeField]
    private GameObject [] _prefabs;
    
    [SerializeField]
    private GameObject _particlesPrefab;

    private void Awake()
    {
        _prefabs[Random.Range(0,_prefabs.Length)].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Root"))
        {
            Collected?.Invoke(this);
            CollectedEffects?.Invoke();
            Instantiate(_particlesPrefab);
            Destroy(gameObject);
        }
    }
}
