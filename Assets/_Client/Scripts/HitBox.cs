using UnityEngine;

public class HitBox : MonoBehaviour 
{
    [SerializeField] protected float _maxHealth;
    protected float _health;

    private void Start()
    {
        _health = _maxHealth;
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