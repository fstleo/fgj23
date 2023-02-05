using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabs;

    [SerializeField] private Collectible[] _predefinedCollectibles;

    [SerializeField] private float _offset;
    
    [SerializeField]
    private float _spawnDistance;

    [SerializeField] private int _amount;
    
    private void Awake()
    {
        foreach (var collectible in _predefinedCollectibles)
        {
            collectible.Collected += CollectTreasure;
        }
        for (int i = 1; i < _amount + 1; i++)
        {
            SpawnTreasure(i);       
        }
    }

    private void SpawnTreasure(int index)
    {
        var collectible = Instantiate(
            _prefabs[Random.Range(0, _prefabs.Length)],
            transform.position + Quaternion.Euler(0,0, Random.Range(-60,60)) * Vector3.down * (_offset + _spawnDistance * index), 
            Quaternion.Euler(Random.Range(0,360), Random.Range(0,360),Random.Range(0,360))).GetComponent<Collectible>();

        if (collectible != null)
        {
            collectible.Collected += CollectTreasure;    
        }
    }

    private void CollectTreasure(Collectible obj)
    {
        ScoresHolder.Scores++;
    }

}