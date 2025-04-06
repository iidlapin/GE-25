using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SpawnerManager spawnerManager;
    public int score { get; private set; }

    private void Start()
    {
        spawnerManager.StartSpawningEnemies();
    }

    public void IncrementScore()
    {
        score++;
    }
}
