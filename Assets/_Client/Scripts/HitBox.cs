using UnityEngine;

public class HitBox : MonoBehaviour 
{
    public float maxHealth;
    protected float _health;

    private void Start()
    {
        _health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)    
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}