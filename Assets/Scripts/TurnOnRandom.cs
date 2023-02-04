using UnityEngine;
using Random = UnityEngine.Random;

public class TurnOnRandom : MonoBehaviour
{
    [SerializeField]
    private GameObject [] _things;

    private void Awake()
    {
        var randomNumber = Random.Range(0, _things.Length);
        for (int i = 0; i < _things.Length; i++)
        {
            _things[i].SetActive(randomNumber == i);    
        }
        
    }
}