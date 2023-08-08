using System.Collections;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _itemPrefabs;
    [SerializeField] int _itemSpawnChance = 5;
    [SerializeField] int _spawnWaitTime = 10; 
    void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    IEnumerator ItemSpawn()
    {
        yield return new WaitForSeconds(_spawnWaitTime);
        int r = Random.Range(0, 10);
        if (r <= _itemSpawnChance)
        {
            float randomX = Random.Range(-2, 2);
            print("ItemSpawn");
            Instantiate(_itemPrefabs[0], new Vector2(randomX, transform.position.y), Quaternion.identity);
        }
        else
        {
            print("ItemSpawnMiss");
        }
        StartCoroutine(ItemSpawn());
    }
}
