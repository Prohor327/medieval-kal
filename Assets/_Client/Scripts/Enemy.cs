using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour 
{
    [SerializeField] private float _chaseRange;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    private SkeletonBigState _state;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }

    private void Update()
    {
        bool currentPlayerInChaseRange = Physics.CheckSphere(transform.position, _chaseRange, _playerLayer);
        bool currentPlayerInAttackRange = Physics.CheckSphere(transform.position, _attackRange, _playerLayer);

        if(currentPlayerInAttackRange && currentPlayerInChaseRange) {   }
        else if(!currentPlayerInAttackRange && currentPlayerInChaseRange)
        {
            _agent.SetDestination(Player.Instance.transform.position);
            _animator.Play("Walk");
        }
        else if(!currentPlayerInAttackRange && !currentPlayerInChaseRange) {   }
    }
}