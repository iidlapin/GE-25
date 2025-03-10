using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public float health = 100f;

    // Abstract method (must be implemented by child classes)
    public abstract void Attack();

    // Non-abstract method (shared behavior)
    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log(gameObject.name + " took " + amount + " damage! Remaining health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // Private method for dying (only used in this class)
    private void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject);
    }
}
