using UnityEngine;

public class DangerousThingy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Root"))
        {
            var poisonDetector = other.GetComponent<PoisonDetector>();
            poisonDetector.DetectPoison();
        }
    }
}