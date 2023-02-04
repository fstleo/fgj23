using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prefabs;

    [SerializeField] private Collectible[] _predefinedCollectibles; 
    
    [SerializeField]
    private float _spawnDistance;

    private void Awake()
    {
        foreach (var collectible in _predefinedCollectibles)
        {
            collectible.Collected += CollectTreasure;
        }
        for (int i = 0; i < 5; i++)
        {
            SpawnTreasure(i);       
        }
    }

    private void SpawnTreasure(int index)
    {
        var collectible = Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], transform.position + Quaternion.Euler(0,0, Random.Range(-60,60)) * Vector3.down * _spawnDistance * index, Quaternion.identity);
        collectible.GetComponent<Collectible>().Collected += CollectTreasure;
    }

    private void CollectTreasure(Collectible obj)
    {
        Debug.Log("Treasure collected");
        ScoresHolder.Scores++;
        
        Destroy(obj.gameObject);
    }

}