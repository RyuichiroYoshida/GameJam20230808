using System.Collections;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] _itemPrefabs;
    void Start()
    {
        StartCoroutine(ItemSpawn());
    }

    IEnumerator ItemSpawn()
    {
        yield return new WaitForSeconds(15);
        int r = Random.Range(0, 10);
        if (r <= 3)
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
