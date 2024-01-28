using System.Collections;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
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
            float prob = Random.Range(0, 100);
            GameObject enemy = enemyPrefab[Random.Range(0,enemyPrefab.Length)];
            if (GameManager.Instance.CurrentState == GameState.Gameplay && prob >= 60) Instantiate(enemy, transform.position, Quaternion.identity,container.transform);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
}
