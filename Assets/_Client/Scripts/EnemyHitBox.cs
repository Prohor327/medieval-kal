using UnityEngine;

public class EnemyHitBox : HitBox
{
    [SerializeField] private Enemy _enemy;

    protected override void Die()
    {
        print("asdasdas");
        _enemy.Die();
    }
}