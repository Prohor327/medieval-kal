using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField] private float _chaseRange;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _playerLayer;

    private SkeletonBigState _state;
    
    private Vector3 playerPosition => Player.Instance.transform.position;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }

    private void Update()
    {
        bool currentPlayerInChaseRange = Physics.CheckSphere(playerPosition, _chaseRange, _playerLayer);
        bool currentPlayerInAttackRange = Physics.CheckSphere(playerPosition, _attackRange, _playerLayer);
        
        print(currentPlayerInChaseRange);
        print(currentPlayerInAttackRange);

        //print(playerPosition);

        if(currentPlayerInAttackRange && currentPlayerInChaseRange)
        {
            //print("Attack");
        }
        else if(!currentPlayerInAttackRange && currentPlayerInChaseRange)
        {
            //print("Chase");
        }
        else if(!currentPlayerInAttackRange && !currentPlayerInChaseRange)
        {
            //print("Idle");
        }
    }
}