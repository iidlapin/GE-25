using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject ballPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SpawnBall();
    }

    private void SpawnBall()
    {
        GameObject followingBall = new GameObject();
        followingBall.name = "FollowingBall";
        followingBall.AddComponent<BallBehaviour>();

        Instantiate(ballPrefab, followingBall.transform);
    }
}