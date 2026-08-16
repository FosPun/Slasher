using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _MyGame.Player.Scripts
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Action OnDodgeInput;
        public Action OnJumpInput;
        public Action<AttackInput> OnLightInput;
        public Action<AttackInput> OnHeavyInput;

        public Vector3 MovementInput { get; private set;}
    
        [Header("Input Actions References")]
        [SerializeField] private InputActionReference moveActionReference;
        [SerializeField] private InputActionReference dodgeActionReference;
        [SerializeField] private InputActionReference jumpActionReference;
        [SerializeField] private InputActionReference lightActionReference;
        [SerializeField] private InputActionReference heavyActionReference;

        private void OnEnable()
        {
            moveActionReference.action.Enable();
            dodgeActionReference.action.Enable();
            jumpActionReference.action.Enable();
            lightActionReference.action.Enable();
            heavyActionReference.action.Enable();
        }

        private void OnDisable()
        {
            moveActionReference.action.Disable();
            dodgeActionReference.action.Disable();
            jumpActionReference.action.Disable();
            lightActionReference.action.Disable();
            heavyActionReference.action.Disable();
        }

        private void Update()
        {
            ReadInput();
        }
        private void ReadInput()
        {
            MovementInput = new Vector3
            (
                moveActionReference.action.ReadValue<Vector2>().x,
                0,
                moveActionReference.action.ReadValue<Vector2>().y 
            );
            if(dodgeActionReference.action.WasPressedThisFrame())
            {
                OnDodgeInput?.Invoke();
            }

            if (jumpActionReference.action.WasPressedThisFrame())
            {
                OnJumpInput?.Invoke();
            }

            if (lightActionReference.action.WasPressedThisFrame())
            {
                OnLightInput?.Invoke(AttackInput.Light);
            }
            if (heavyActionReference.action.WasPressedThisFrame())
            {
                OnHeavyInput?.Invoke(AttackInput.Heavy);
            }
        }
    }
}
