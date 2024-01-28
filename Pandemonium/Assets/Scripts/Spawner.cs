using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject container;
    public float spawnInterval = 2f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity,container.transform);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
}
