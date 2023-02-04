using System;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    public event Action<Collectible> Collected;

    public UnityEvent CollectedEffects;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Root"))
        {
            Collected?.Invoke(this);
            CollectedEffects?.Invoke();
        }
    }
}
