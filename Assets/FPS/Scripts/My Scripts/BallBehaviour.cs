using Unity.FPS.Gameplay;
using UnityEngine;

public class BallBehaviour : Obstacle
{
    // Creating reference to player's transform
    private Transform player;
    // Setting the speed that the object follows the player
    public float FollowSpeed = 5f;

    // Setting the height of the object

    public float FixedHeight = 1f;

    public float attackPower = 10f;

    // Implementing the abstract Attack method
    public override void Attack()
    {
        Debug.Log("Ball attacks with " + attackPower + " damage!");
    }

private void Start()
    {
        player = FindFirstObjectByType<PlayerCharacterController>().transform;
    }

    void Update()
    {
        // Making sure that the player reference is set
        if(player != null)
        {
            // Calculate the direction of the ball to the player
            Vector3 direction = player.position - transform.position;
            Vector3 movement = direction.normalized * FollowSpeed* Time.deltaTime;

            //Move the ball while keeping it's height fixed
            transform.position += movement;
            transform.position= new Vector3(transform.position.x, FixedHeight,transform.position.z);
        }
    }
}
