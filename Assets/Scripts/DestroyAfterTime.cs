using System.Collections;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float _pause;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_pause);
        Destroy(gameObject);
    }
}