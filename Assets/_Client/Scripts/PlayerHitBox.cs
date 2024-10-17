using System;
using UnityEngine;

public class PlayerHitBox : HitBox 
{
    public Action<float> OnTakeDamage;

    public void TakeDamage(float damage, Enemy enemy)
    {
        if(Player.Instance.combatState == PlayerCombatState.Blocking)
        {
            enemy.Hit();
            Player.Instance.Impact();
            return;
        }
        _health -= damage;
        OnTakeDamage.Invoke(_health);
        if (_health <= 0)    
        {
            OnTakeDamage.Invoke(0);
            Die();
            return;
        }
        Player.Instance.Hit();
    }

    protected override void Die()
    {
        Player.Instance.Die();
    }
}