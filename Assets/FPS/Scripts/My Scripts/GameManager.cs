using UnityEngine;
using AG3787;
public class GameManager : MonoBehaviour
{

    public GameObject AttackingBall;

    void Start()
    {
        // Spawn a ball
      GameObject newBall = Instantiate(AttackingBall, Vector3.zero, Quaternion.identity);
      BallBehaviour ballScript = newBall.GetComponent<BallBehaviour>();

        // Make the ball attack and take damage
      ballScript.Attack();
      ballScript.TakeDamage(30);
    }
}