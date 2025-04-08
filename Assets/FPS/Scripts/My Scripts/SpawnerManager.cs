using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private Vector2 spawningInterval;
    [SerializeField] private GameObject coin;
    [SerializeField] private Bounds spawningArea;
  
    public void StartSpawning()
    {
        StartCoroutine(EnemySpawningCycle());
    }

    private IEnumerator EnemySpawningCycle()
    {
        while (true) 
        {
            int randomEnemyIndex = Random.Range(0, enemies.Count);

            Instantiate(enemies[randomEnemyIndex], GetRandomPosition(), Quaternion.identity, transform);

            yield return new WaitForSeconds(GetRandomSpawnInterval());
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomSpawnPosition = new Vector3
                (
                    Random.Range(spawningArea.min.x, spawningArea.max.x),
                    spawningArea.max.y,
                    Random.Range(spawningArea.min.z, spawningArea.max.z)
                );

        return randomSpawnPosition; 
    }

    public void SpawnCoin(Vector3 deathPos) 
    {
        Instantiate(coin, deathPos, Quaternion.identity);
    }

    private float GetRandomSpawnInterval()
    {
       return Random.Range(spawningInterval.x, spawningInterval.y);
    }
}