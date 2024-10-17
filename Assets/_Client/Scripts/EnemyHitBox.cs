using UnityEngine;

public class EnemyHitBox : HitBox
{
    [SerializeField] private Enemy _enemy;

    protected override void Die()
    {
        _enemy.Die();
    }
}