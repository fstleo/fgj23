using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _goods;

    [SerializeField]
    private GameObject[] _bads;

    
    [SerializeField] private float _goodWeight;
    [SerializeField] private float _badWeight;
    [SerializeField] private float _emptyWeight;
    
    [SerializeField]
    private int _spawnDistance;

    [SerializeField]
    private int _notSpawnRadius;
    
    [SerializeField]
    private int _step;
    
    private float _maxWeight;
    private int _goodChance;
    private int _badChance;
    
    private void Awake()
    {
        _maxWeight = _goodWeight + _badWeight + _emptyWeight;
        _goodChance = Mathf.RoundToInt(100*_goodWeight / _maxWeight);
        _badChance = Mathf.RoundToInt(100*_badWeight / _maxWeight);
        
        for (int i = -_spawnDistance; i < _spawnDistance; i+=_step)
        for (int j = -_spawnDistance; j < 0; j+= _step)
        {
            if (Mathf.Abs(i) < _notSpawnRadius && Mathf.Abs(j) < _notSpawnRadius)
            {
                continue;
            }
            SpawnTreasure(i, j);       
        }
    }

    private void SpawnTreasure(int x, int y)
    {
        GameObject prefab;
        var randomThing = Random.Range(0, 100);
        if (randomThing <= _goodChance)
        {
            prefab = _goods[Random.Range(0, _goods.Length)];
        }
        else if (randomThing < _goodChance + _badChance)
        {
            prefab = _bads[Random.Range(0, _goods.Length)];
        }
        else
        {
            return;
        }
        var collectible = Instantiate(
            prefab,
             new Vector3(Random.Range(x, x+_step), Random.Range(y, y+_step), 0),
            Quaternion.identity).GetComponentInChildren<Collectible>();

        if (collectible != null)
        {
            collectible.Collected += CollectTreasure;    
        }
    }

    private void CollectTreasure(Collectible obj)
    {
        ScoresHolder.Scores++;
        obj.Collected -= CollectTreasure;
    }

}