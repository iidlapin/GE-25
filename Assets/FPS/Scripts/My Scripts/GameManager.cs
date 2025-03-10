using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SpawnerManager spawnerManager;

    private void Start()
    {
        spawnerManager.StartSpawningEnemies();
    }
}
