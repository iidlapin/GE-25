using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private Vector2 spawningInterval;
    [SerializeField] private GameObject coin;
    [SerializeField] private Bounds spawningArea;
    [SerializeField] private float coinSpawnOffset = 0.5f;

    [SerializeField] List<Transform> spawningTransforms = new();

    [SerializeField] private Transform player;

    public void StartSpawning()
    {
        StartCoroutine(EnemySpawningCycle());
    }
    
    
    private IEnumerator EnemySpawningCycle()
    {
        while (true) 
        {
            int randomEnemyIndex = Random.Range(0, enemies.Count);

            Instantiate(enemies[randomEnemyIndex], CheckForCloserSpawnPoint(), Quaternion.identity);

            yield return new WaitForSeconds(GetRandomSpawnInterval());
        }
    }

    private Vector3 CheckForCloserSpawnPoint()
    {
        //By default sets the first point in the list as closest point
        var closestPos = spawningTransforms[0];

        //goes through all of the points in the list
        for (int i = 0; i < spawningTransforms.Count; i++)
        {
            //Calculates the distance between the player and the point which we are looping through
            var distanceWithCurrentPoint = Vector3.Distance(player.position, spawningTransforms[i].position);

            //Check if the current point is closer than the previously closest point
            if ( distanceWithCurrentPoint < Vector3.Distance(player.position,closestPos.position))
            {
                //If yes, sets the current point as the new closest point
                closestPos = spawningTransforms[i];
            }
        }

        //When the loop has gone through all the points, then it returns whatever was the closest one
        return closestPos.position;
    }

    public void SpawnCoin(Vector3 deathPos) 
    {
        var offset = new Vector3
            (
                Random.Range(-coinSpawnOffset, coinSpawnOffset),
                0f,
                Random.Range(-coinSpawnOffset, coinSpawnOffset)
            );

        Instantiate(coin, deathPos + offset, Quaternion.identity);
    }

    private float GetRandomSpawnInterval()
    {
       return Random.Range(spawningInterval.x, spawningInterval.y);
    }
}