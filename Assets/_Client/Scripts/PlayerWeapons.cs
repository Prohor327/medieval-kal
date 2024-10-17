using UnityEngine;

public class PlayerWeapons : MonoBehaviour 
{
    [SerializeField] private Animator _animator;

    private void Attack()
    {
        if (Player.Instance.combatState == PlayerCombatState.Idle || Player.Instance.combatState == PlayerCombatState.Blocking)
        {
            _animator.SetLayerWeight(1, 1.0f);
            Player.Instance.SetCombatState(PlayerCombatState.Attack);
            _animator.Play("Attack1");
            Player.Instance.Movement.SetMove(false);
        }
    }

    private void Block()
    {
        if(Player.Instance.combatState == PlayerCombatState.Idle)
        {
            Player.Instance.SetCombatState(PlayerCombatState.Block);
            _animator.SetLayerWeight(1, 0.5f);
            _animator.Play("Block");
        }
    }

    private void Unblock()
    {
        if (Player.Instance.combatState == PlayerCombatState.Blocking)
        {
            Player.Instance.SetCombatState(PlayerCombatState.Unblock);
            _animator.Play("Unblock");
        }
    }

    private void Update() 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
        else if(Input.GetButtonDown("Fire2"))
        {
            Block();
        }
        else if(Input.GetButtonUp("Fire2"))
        {
            Unblock();
        }
    }  

    private void FinishAttack()
    {
        Player.Instance.SetCombatState(PlayerCombatState.Idle);
        _animator.SetLayerWeight(1, 0.0f);
        Player.Instance.Movement.SetMove(true);
    }

    private void FinishBlock()
    {
        Player.Instance.SetCombatState(PlayerCombatState.Blocking);
    }

    private void FinishUnblock()
    {
        Player.Instance.SetCombatState(PlayerCombatState.Idle);
        _animator.SetLayerWeight(1, 0.0f);
    }
}