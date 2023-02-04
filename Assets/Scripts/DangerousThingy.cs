using UnityEngine;
using UnityEngine.Events;

public class DangerousThingy : MonoBehaviour
{
    [SerializeField] private UnityEvent _hit; 
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Root"))
        {
            var poisonDetector = other.GetComponent<PoisonDetector>();
            poisonDetector.DetectPoison();
            _hit?.Invoke();
        }
    }
}