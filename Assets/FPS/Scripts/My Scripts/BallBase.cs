using System.Collections;
using System.Linq;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;


//BallBase needs to inherit from Damageable beacause that is the class used by the projectiles to apply damage
public abstract class BallBase : Damageable, IFollower
{
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float fixedHeight = 1f;

    [SerializeField] private bool dealsDamage = true;
    [SerializeField] private float damageRadius = 3f;
    [SerializeField] private float damageInterval = 1f;
    [SerializeField] protected int damage = 10;
    [SerializeField] private int numberOfCoinsOnDeath = 1;
     
    [SerializeField] private GameObject deathVFX;

    public bool CanMove = true;

    private Transform player;
    private bool isPlayerInRange;

    public Transform target
    {
        get => player;
        set => player = value;
    }

    public virtual void Start()
    {
        player = FindFirstObjectByType<PlayerCharacterController>().transform;
        //Subscribe to the OnDie action in the Health class so we know when the enemy is killed and we can call our Die function
        Health.OnDie += Die;
        CanMove = true;
    }

    private void Update()
    {
        Follow();
    }

    protected abstract void Attack();

    public void Follow()
    {
        if (!CanMove) return;

        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            Vector3 movement = direction.normalized * followSpeed * Time.deltaTime;

            transform.position += movement;
            transform.position = new Vector3(transform.position.x, fixedHeight, transform.position.z);

            isPlayerInRange = Vector3.Distance(transform.position, target.position) < damageRadius;
            
        }
    }

    protected IEnumerator DamagePlayer(int damage)
    {
        while (dealsDamage)
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

        for (int i = 0; i < numberOfCoinsOnDeath; i++)
            GetComponentInParent<SpawnerManager>().SpawnCoin(transform.position);

        Destroy(this.gameObject);
    }

    private void HandleDeathVFX()
    {
        //Create the VFX and mark it for destruction in 3 seconds
        var explosionVFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosionVFX, 3f);
    }
}

