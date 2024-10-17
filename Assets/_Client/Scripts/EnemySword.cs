using UnityEngine;

public class EnemySword : Sword 
{
    [SerializeField] private Enemy enemy;

    protected override void TryAcceptWeaponVisitor(Collider collider)
    {
        if(collider.gameObject.TryGetComponent(out PlayerHitBox hitBox))
        {
            hitBox.TakeDamage(_damage, enemy);
        }
    }
}