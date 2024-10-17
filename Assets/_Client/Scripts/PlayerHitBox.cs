using UnityEngine;

public class PlayerHitBox : HitBox 
{
    public void TakeDamage(float damage, Enemy enemy)
    {
        if(Player.Instance.combatState == PlayerCombatState.Blocking)
        {
            enemy.Hit();
            return;
        }
        _health -= damage;
        if (_health <= 0)    
        {
            Die();
        }
    }

    protected override void Die()
    {
        Player.Instance.Die();
    }
}