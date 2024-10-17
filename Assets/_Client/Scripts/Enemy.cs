using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

public class Enemy : MonoBehaviour 
{
    [SerializeField] private float _chaseRange;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _turnSmoothTime = 0.1f;


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

        if(_state != SkeletonBigState.Hit)
        {
            if(currentPlayerInAttackRange && currentPlayerInChaseRange && _state != SkeletonBigState.Death)
            {
                _state = SkeletonBigState.Attack;
                _animator.Play("Attack");
            }
            else if(!currentPlayerInAttackRange && currentPlayerInChaseRange && _state != SkeletonBigState.Death)
            {
                _state = SkeletonBigState.Walk;
                _agent.SetDestination(Player.Instance.transform.position);
                _animator.Play("Walk");
            }
            else if(!currentPlayerInAttackRange && !currentPlayerInChaseRange && _state != SkeletonBigState.Death) 
            {
                _state = SkeletonBigState.Idle;
                _agent.SetDestination(transform.position);
                _animator.Play("Idle");
            }
        }
    }

    public void FinishAttack()
    {
        transform.LookAt(Player.Instance.transform.position);   
    }

    public void Hit()
    {
        _animator.Play("Hit");
        _state = SkeletonBigState.Hit;
    }

    public void FinishHit()
    {
        _state = SkeletonBigState.Idle;
    }

    public void Die()
    {
        _state = SkeletonBigState.Death;
        _animator.Play("Die");
    }
}