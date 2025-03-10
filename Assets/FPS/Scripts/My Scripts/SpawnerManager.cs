using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SpawnBall();
    }

    private void SpawnBall()
    {
        int randomEnemyIndex = Random.Range(0, enemies.Count);

        Instantiate(enemies[randomEnemyIndex], Vector3.zero, Quaternion.identity);
    }
}