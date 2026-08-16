using UnityEngine;
using Zenject;
using System;
using _MyGame.Player.Scripts.StateMachine;

namespace _MyGame.Player.Scripts
{
    public class Combat : MonoBehaviour
    {
        public Action OnAttackFinish;
        
        [Header("Combat Settings")]
        [SerializeField] private AttackSO baseLightAttack;
        [SerializeField] private AttackSO baseHeavyAttack;
        [SerializeField] private LayerMask layerMaskToHit;
        
        private Collider[] _hitColliders = new Collider[20]; 
        
        private PlayerInputHandler _playerInputHandler;
        private PlayerCharacter _playerCharacter;
        private PlayerAnimator _playerAnimator;
        private PlayerDataSO _playerData;

        public AttackSO CurrentActiveAttack { get; private set; }
        
        private int _comboStep = 0;
        private bool _isAttacking = false;
        private bool _comboWindowOpened = false;
        private AttackInput? _bufferedInput; 
        
        [Inject]
        private void Construct(PlayerInputHandler playerInputHandler, PlayerCharacter playerCharacter, PlayerAnimator playerAnimator, PlayerDataSO playerData)
        {
            _playerInputHandler = playerInputHandler;
            _playerCharacter = playerCharacter;
            _playerAnimator = playerAnimator;
            _playerData = playerData;
        }
        
        private void OnEnable()
        {
            _playerInputHandler.OnLightInput += TryAttack;
            _playerInputHandler.OnHeavyInput += TryAttack;
            
            _playerAnimator.OnComboWindowOpened += OpenComboWindow;
            _playerAnimator.OnAttackAnimationFinished += FinishAttack;
            _playerAnimator.OnAttack += AttackCast;
        }

        private void OnDisable()
        { 
            _playerInputHandler.OnLightInput -= TryAttack;
            _playerInputHandler.OnHeavyInput -= TryAttack;
            
            _playerAnimator.OnComboWindowOpened -= OpenComboWindow;
            _playerAnimator.OnAttackAnimationFinished -= FinishAttack;
            _playerAnimator.OnAttack -= AttackCast;
        }

        private void TryAttack(AttackInput input)
        { 
            if(_playerCharacter.StateMachine.CurrentState is DodgeState) return;
            if (_isAttacking && !_comboWindowOpened)
            {
                _bufferedInput = input;
                return;
            }

            ExecuteAttack(input);
        }

        private void ExecuteAttack(AttackInput input)
        {
            AttackSO nextAttack = GetNextAttack(input);
            
            if (nextAttack == null) return; 
            if (!_playerData.IsUnlocked(nextAttack)) return;
            CurrentActiveAttack = nextAttack;
            _comboStep++;
            
            _isAttacking = true;
            _comboWindowOpened = false;
            _bufferedInput = null;
            
            _playerCharacter.Attack(CurrentActiveAttack.animationLabel);
        }

        private void OpenComboWindow()
        {
            _comboWindowOpened = true;
            
            if (_bufferedInput.HasValue)
            {
                ExecuteAttack(_bufferedInput.Value);
            }
        }

        private AttackSO GetNextAttack(AttackInput input)
        {
            if (_comboStep > 0 && CurrentActiveAttack != null)
            {
                var transition = CurrentActiveAttack.transitions.Find(t => t.attackInput == input);
                return transition;
            }
            return input == AttackInput.Light ? baseLightAttack : baseHeavyAttack;
        }

        private void FinishAttack()
        {
            ResetState();
            OnAttackFinish?.Invoke();
        }

        private void ResetState()
        {
            _comboStep = 0;
            _isAttacking = false;
            _comboWindowOpened = false;
            _bufferedInput = null;
            CurrentActiveAttack = null;
        }

        private void AttackCast()
        {
            if (CurrentActiveAttack == null) return;

            Vector3 hitPosition = transform.position + (transform.forward * CurrentActiveAttack.positionOffset);
            int hits = Physics.OverlapSphereNonAlloc(hitPosition, CurrentActiveAttack.radius, _hitColliders, layerMaskToHit);

            for (int i = 0; i < hits; i++)
            {
                if (_hitColliders[i].TryGetComponent(out Health health))
                {
                    health.TakeDamage(CurrentActiveAttack.damage);
                }

                if (CurrentActiveAttack.effects != null)
                {
                    foreach (var effectSo in CurrentActiveAttack.effects)
                    {
                        if (effectSo != null)
                        {
                            effectSo.Apply(gameObject, _hitColliders[i].gameObject);
                        }
                    }
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            if(CurrentActiveAttack == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + (transform.forward * CurrentActiveAttack.positionOffset), CurrentActiveAttack.radius);
        }
    }
}