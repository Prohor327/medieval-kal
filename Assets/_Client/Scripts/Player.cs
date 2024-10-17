using System.Runtime;
using UnityEngine;

public class Player : PersistentSingleton<Player> 
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _impactSound;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _deathSound;

    public PlayerHitBox hitBox;

    private PlayerCombatState _combatState = PlayerCombatState.None;
    private PlayerMovementState _movementState = PlayerMovementState.None;

    public PlayerCombatState combatState => _combatState;
    public PlayerMovementState movementState => _movementState;
    public PlayerMovement Movement => _playerMovement;

    private void Start()
    {
        _combatState = PlayerCombatState.Idle;
        _movementState = PlayerMovementState.Idle;
    }

    public void SetCombatState(PlayerCombatState state)
    {   
        _combatState = state;
    }

    public void SetMovementState(PlayerMovementState state)
    {
        _movementState = state;
    }

    public void Die()
    {
        _combatState = PlayerCombatState.Death;
        _movementState = PlayerMovementState.Death;
        _animator.SetLayerWeight(1, 0);
        _animator.Play("Death");
        _audioSource.PlayOneShot(_deathSound);
    }

    public void Impact()
    {
        _animator.Play("Impact");
    }

    public void Hit()
    {
        _audioSource.PlayOneShot(_hitSound);
    }
}