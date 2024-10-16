using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : PersistentSingleton<Player> 
{
    [SerializeField] private PlayerMovement _playerMovement;

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
}