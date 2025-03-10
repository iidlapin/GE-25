using System.Collections;
using System.Linq;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;


//BallBase needs to inherit from Damageable beacause that is the class used by the projectiles to apply damage
public abstract class BallBase : Damageable
{
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float fixedHeight = 1f;
    [SerializeField] private float damageRadius = 3f;
    [SerializeField] private float damageInterval = 1f;
    [SerializeField] private float damage = 10f;
     
    [SerializeField] private GameObject deathVFX;

    private Transform player;
    private bool isPlayerInRange;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerCharacterController>().transform;

        StartCoroutine(DamagePlayer());
        //Subscribe to the OnDie event in the Health class so we know when the enemy is killed and we can call our Die function
        Health.OnDie += Die;
    }

    private void Update()
    {
        BallMovement();
    }

    protected abstract void Attack();

    protected virtual void BallMovement()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            Vector3 movement = direction.normalized * followSpeed * Time.deltaTime;

            transform.position += movement;
            transform.position = new Vector3(transform.position.x, fixedHeight, transform.position.z);

            if (Vector3.Distance(transform.position, player.position) < damageRadius)
                isPlayerInRange = true;
            else
                isPlayerInRange = false;
            
        }
    }

    private IEnumerator DamagePlayer()
    {
        while (true)
        {
            if (isPlayerInRange)
            {
                player.GetComponent<Damageable>().InflictDamage(damage, false, this.gameObject);
                yield return new WaitForSeconds(damageInterval);
            }
            else
                yield return new WaitForEndOfFrame();
        }
    }

    private void Die()
    {
        HandleDeathVFX();
        Destroy(this.gameObject);
    }

    private void HandleDeathVFX()
    {
        //Create the VFX and mark it for destruction in 3 seconds
        var explosionVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosionVFX, 3f);
    }
}
