using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private float spawningInterval;

    public void StartSpawningEnemies()
    {
        StartCoroutine(SpawningCycle());
    }

    private IEnumerator SpawningCycle()
    {
        while (true) 
        {
            int randomEnemyIndex = Random.Range(0, enemies.Count);

            Instantiate(enemies[randomEnemyIndex], Vector3.zero, Quaternion.identity);

            yield return new WaitForSeconds(spawningInterval);
        }
    }
}