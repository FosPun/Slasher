using System;
using UnityEngine;

public class CombatAnimator : MonoBehaviour
{
    public Action OnAttackAnimationFinished;
    public Action OnComboWindowOpened;
    public Action OnComboWindowClosed;
    public Action OnAttack;
    
    public void AnimationEvent_AttackFinished() => OnAttackAnimationFinished?.Invoke();
    public void AnimationEvent_OpenComboWindow() => OnComboWindowOpened?.Invoke();
    public void AnimationEvent_OpenComboClosed() => OnComboWindowClosed?.Invoke();
    public void AnimationEvent_Attack() => OnAttack?.Invoke();
}
