using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _MyGame.Player.Scripts
{
    public class PlayerAnimator : MonoBehaviour
    {
        public Action OnAttackAnimationFinished;
        public Action OnComboWindowOpened;
        public Action OnComboWindowClosed;
        public Action OnAttack;
    
        [Header("Animator Parameters")]
        [SerializeField] private string movingBoolName = "IsMoving";
        [SerializeField] private string airBoolName = "InAir";
        [SerializeField] private string onGroundBoolName = "OnGround";
        [SerializeField] private string idleBoolName = "IsIdle";
        [SerializeField] private string jumpBoolName = "IsJump";
        [SerializeField] private string attackBoolName = "IsAttacking";
        [SerializeField] private string dodgeBoolName = "IsDodging";
        [SerializeField] private string jumpTriggerName = "Jump";
        
        [SerializeField] private string comboFinishedTrigger = "ComboFinishedTrigger";
        
        private Animator _animator;
        
        [Inject]
        private void Construct(Animator animator)
        {
            _animator = animator;
        }
        public void CrossFadeAttack(string animationName)
        {
            _animator.CrossFade(animationName, 0.1f);
        }
        public void AnimationEvent_AttackFinished() => OnAttackAnimationFinished?.Invoke();
        public void AnimationEvent_OpenComboWindow() => OnComboWindowOpened?.Invoke();
        public void AnimationEvent_OpenComboClosed() => OnComboWindowClosed?.Invoke();
        public void AnimationEvent_Attack() => OnAttack?.Invoke();
        public void SetIsMoving(bool state) => _animator.SetBool(movingBoolName, state);
        public void SetIsIdle(bool state) => _animator.SetBool(idleBoolName, state);
        public void SetInAir(bool state) => _animator.SetBool(airBoolName, state);
        public void SetOnGroundBool(bool state) => _animator.SetBool(onGroundBoolName, state);
        public void SetIsJump(bool state) => _animator.SetBool(jumpBoolName, state);
        public void SetJumpTrigger() => _animator.SetTrigger(jumpTriggerName);
        public void SetIsAttacking(bool state) => _animator.SetBool(attackBoolName,state);
        public void SetIsDodging(bool state) => _animator.SetBool(dodgeBoolName, state);
        public void SetComboFinsihedTrigger() => _animator.SetTrigger(comboFinishedTrigger);

    }
}