using UnityEngine;

public class PoisonDetector : MonoBehaviour
{
    [SerializeField] private Root _root;

    public void DetectPoison()
    {
        _root.Die();
    }
}