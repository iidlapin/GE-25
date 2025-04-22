using UnityEngine;

public class MadBall : BallBase
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
