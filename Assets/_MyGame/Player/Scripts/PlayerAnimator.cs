using System;
using UnityEngine;
using Zenject;

public class PlayerAnimator : MonoBehaviour
{
    public Action OnAttackAnimationFinished;
    public Action OnComboWindowOpened;
    
    [Header("Animator Parameters")]
    public float СrossFadeDuration = 0.2f;
    [SerializeField] private string movingBoolName = "IsMoving";
    [SerializeField] private string airBoolName = "InAir";
    [SerializeField] private string onGroundBoolName = "OnGround";
    [SerializeField] private string idleBoolName = "IsIdle";
    [SerializeField] private string jumpBoolName = "IsJump";
    [SerializeField] private string attackBoolName = "IsAttacking";
    [SerializeField] private string jumpTriggerName = "Jump";
    
    [SerializeField] private string attackStateName = "AttackState";
    [SerializeField] private AnimationClip baseAttackClip;
    
    private Animator _animator;
    
    private AnimationClip attackClip;
    private AnimatorOverrideController _animatorOverrideController;

    [Inject]
    private void Construct(Animator animator)
    {
        _animator = animator;
    }
    private void Start()
    {
        _animatorOverrideController = new AnimatorOverrideController(_animator.runtimeAnimatorController);
        _animator.runtimeAnimatorController = _animatorOverrideController;
    }
    public void PlayAttackAnimation(AnimationClip clip)
    {
        _animatorOverrideController[baseAttackClip] = clip;
        _animator.CrossFadeInFixedTime(attackStateName, СrossFadeDuration);
    }
    
    public void AnimationEvent_AttackFinished() => OnAttackAnimationFinished?.Invoke();
    public void AnimationEvent_OpenComboWindow() => OnComboWindowOpened?.Invoke();
    public void SetIsMoving(bool state) => _animator.SetBool(movingBoolName, state);
    public void SetIsIdle(bool state) => _animator.SetBool(idleBoolName, state);
    public void SetInAir(bool state) => _animator.SetBool(airBoolName, state);
    public void SetOnGroundBool(bool state) => _animator.SetBool(onGroundBoolName, state);
    public void SetIsJump(bool state) => _animator.SetBool(jumpBoolName, state);
    public void SetJumpTrigger() => _animator.SetTrigger(jumpTriggerName);
    public void SetIsAttacking(bool state) => _animator.SetBool(attackBoolName,state);

}