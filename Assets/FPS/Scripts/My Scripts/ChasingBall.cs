using Unity.FPS.Gameplay;
using UnityEngine;

public class ChasingBall : BallBase
{
    public override void Start()
    {
        base.Start();
        Attack();
    }

    protected override void Attack()
    {
        StartCoroutine(DamagePlayer(damage));
    }
}
