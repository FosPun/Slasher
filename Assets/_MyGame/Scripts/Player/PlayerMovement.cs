using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Action OnJump;
    
    public CharacterController CharacterController => _characterController;
    [SerializeField] private float speed;
    [SerializeField] private float dodgeDistance;
    [SerializeField] private float jumpPower;
    [SerializeField] private float gravity;
    [SerializeField] private float rotationSpeed;
   
    private bool _isMoving = true;
    
    private PlayerInputHandler _playerInputHandler;
    private CharacterController _characterController;

    private Vector3 _velocity;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInputHandler = GetComponent<PlayerInputHandler>();

        speed = GetComponent<Character>().MovementSpeed;
    }

    private void OnEnable()
    {
        _playerInputHandler.OnDodgeInput += DodgeHandle;
        _playerInputHandler.OnJumpInput += JumpHandler;
    }

    private void OnDisable()
    {
        _playerInputHandler.OnDodgeInput -= DodgeHandle;
        _playerInputHandler.OnJumpInput -= JumpHandler;
    }

    private void Update()
    {
        GravityHandler();
        MovementHandler();
        RotationHandler();
        Move();
        
    }

    private void RotationHandler()
    {
        if (!(_playerInputHandler.MovementInput.sqrMagnitude > 0) || !_characterController.isGrounded) return;
        /*Quaternion targetRotation = Quaternion.LookRotation(_playerInputHandler.MovementInput);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);*/
        Quaternion targetRotation = Quaternion.LookRotation(_playerInputHandler.MovementInput.normalized);
        transform.rotation = targetRotation;
    }

    private void GravityHandler()
    {
        if (_characterController.isGrounded)
        {
            _velocity.y = -2f;
        }
        else
        {
            _velocity.y += gravity * Time.deltaTime;
        }
    }
    private void DodgeHandle()
    {
        Vector3 dodgeDirection = new Vector3(_playerInputHandler.MovementInput.x, 0, _playerInputHandler.MovementInput.z);
        _characterController.Move(dodgeDirection * dodgeDistance);
    }

    private void JumpHandler()
    {
        if (!_characterController.isGrounded) return;
        _characterController.Move( Vector3.up * jumpPower);
        OnJump?.Invoke();
        
    }
    
    private void MovementHandler()
    {
            if(!_isMoving && _playerInputHandler.MovementInput.sqrMagnitude < 0 || !_characterController.isGrounded) return;
            _velocity.x =  _playerInputHandler.MovementInput.x * speed;
            _velocity.z =  _playerInputHandler.MovementInput.z * speed;
    }
    private void Move()
    {
        _characterController.Move(_velocity * Time.deltaTime);
        _isMoving = Mathf.Abs(_velocity.x) + Mathf.Abs(_velocity.z) > 0;
    }
}
