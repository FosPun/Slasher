using System;
using UnityEngine;
using Zenject;

    public class PlayerMovement : MonoBehaviour
    {
        public Action OnJump;
        
        public Vector3 Velocity => _velocity;
        [SerializeField] private float speed;
        [SerializeField] private float dodgeDistance;
        [SerializeField] private float jumpPower;
        [SerializeField] private float gravity;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float jumpHeightOnHit;
    
        private PlayerInputHandler _playerInputHandler;
        private CharacterController _characterController;

        private bool _isMoving = true;
        private bool _canMove = true;
        private Vector3 _velocity;

        [Inject] 
        private void Construct(PlayerInputHandler playerInputHandler, CharacterController characterController)
        {
            _playerInputHandler = playerInputHandler;
            _characterController = characterController;
        }
    
        private void Awake()
        {
            speed = GetComponent<Character>().MovementSpeed;
        }

        private void OnEnable()
        {
            _playerInputHandler.OnJumpInput += JumpHandler;
        }

        private void OnDisable()
        {
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
            if (_playerInputHandler.MovementInput.sqrMagnitude <= 0.01f || !_canMove) return;

            Vector3 inputDirection = new Vector3(_playerInputHandler.MovementInput.x, 0, _playerInputHandler.MovementInput.z).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(inputDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        private void GravityHandler()
        {
            if (_characterController.isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }
            else
            {
                _velocity.y += gravity * Time.deltaTime;
            }
        }
    
        private void JumpHandler()
        {
            if (!_characterController.isGrounded) return;
            _velocity.y = jumpPower;
            OnJump?.Invoke();
        }
    
        private void MovementHandler()
        {
            if(!_isMoving && _playerInputHandler.MovementInput.sqrMagnitude <= 0.01f || !_canMove) return;
            _velocity.x =  _playerInputHandler.MovementInput.x * speed;
            _velocity.z =  _playerInputHandler.MovementInput.z * speed;
        }
    
        private void Move()
        {
            _characterController.Move(_velocity * Time.deltaTime);
            _isMoving = Mathf.Abs(_velocity.x) + Mathf.Abs(_velocity.z) > 0;
        }

        public void JumpOnHit()
        {
            _velocity = new Vector3(0, jumpHeightOnHit, 0);
        }
        public void MovementSwitch(bool b)
        {
            _velocity.x = 0;
            _velocity.z = 0;
            _canMove = b;
        }
    }

