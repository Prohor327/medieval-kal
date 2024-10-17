using UnityEngine;

public class Sword : MonoBehaviour 
{
    [SerializeField] protected float _damage;
    [SerializeField] private Transform _overlapPoint;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _attackSound;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_overlapPoint.position, _attackRange);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(_overlapPoint.position, 0.02f);
    }

    public void StartAttack()
    {
    }

    public void PerformAttack()
    {
        _audioSource.PlayOneShot(_attackSound); 
        Collider[] hitColliders = new Collider[10];
        int amountColliders = Physics.OverlapSphereNonAlloc(_overlapPoint.position, _attackRange, hitColliders, _layerMask);
        TryPerformAttack(hitColliders, amountColliders);
    }

    private void TryPerformAttack(Collider[] colliders, int amountColliders)
    {
        for(int i = 0; i < amountColliders; i++)
        {
            TryAcceptWeaponVisitor(colliders[i]);
        }
    }

    protected virtual void TryAcceptWeaponVisitor(Collider collider)
    {
        if(collider.gameObject.TryGetComponent(out HitBox hitBox))
        {
            hitBox.TakeDamage(_damage);
        }
    }
}