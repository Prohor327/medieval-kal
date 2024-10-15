using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class HitBox : MonoBehaviour 
{
    [SerializeField] private float _maxHealth;
    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)    
        {
            Destroy(gameObject);
        }
    }
}