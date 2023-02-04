using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public event Action<Collectible> Collected;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Root"))
        {
            Collected?.Invoke(this);
        }
    }
}
