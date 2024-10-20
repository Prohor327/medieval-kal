using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _shieldSpeed = 3f;
    [SerializeField] private float _turnSmoothTime = 0.1f;
    [SerializeField] private Transform _camera;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioClip[] _footstepClips;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private bool _isCutScene = false;

    private float _turnSmoothVelocity;
    private Vector3 _playerVelocity;
    private bool _movePermission = true;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;    
    }

    public void SoundFootstep()
    {
        _audioSource.PlayOneShot(_footstepClips[Random.Range(0, _footstepClips.Length)]);
    }

    private void Update()
    {
        if (_isCutScene == true) return;
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;

        if(direction == Vector3.zero && Player.Instance.movementState == PlayerMovementState.Walk)
        {   
            Player.Instance.SetMovementState(PlayerMovementState.Idle);
            _animator.Play("Idle");
        }
        else if(direction != Vector3.zero && Player.Instance.movementState == PlayerMovementState.Idle)
        {   
            Player.Instance.SetMovementState(PlayerMovementState.Walk);
            _animator.Play("Walk");
        }

        if(direction.magnitude >= 0.1f && Player.Instance.movementState != PlayerMovementState.Death)
        {
            if(_movePermission)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                if(Player.Instance.combatState == PlayerCombatState.Blocking)
                {
                    _characterController.Move(moveDir.normalized * _shieldSpeed * Time.deltaTime);
                }
                else if(Player.Instance.combatState != PlayerCombatState.Blocking)
                {
                    _characterController.Move(moveDir.normalized * _speed * Time.deltaTime);
                }
            }
        }

        _playerVelocity.y += Physics.gravity.y * Time.deltaTime;

        if (_characterController.isGrounded)
        {
            if (_playerVelocity.y < 0)
            {
                _playerVelocity.y = -2f;
            }
        }
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }

    public void SetMove(bool move)
    {
        _movePermission = move;
    }
}