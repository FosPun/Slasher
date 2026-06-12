using UnityEngine;

public class AttackState : PlayerState
{
    private AttackSO _currentAttackData;
    private AttackSO _nextComboAttack;
    private bool _isComboWindowOpen;
    
    private float _attackStartTime; 

    public void SetInitialAttack(AttackSO attackData)
    {
        _currentAttackData = attackData;
    }

    public override void Enter()
    {
        base.Enter();
        _animator.OnAttackAnimationFinished += FinishAttack;
        _animator.OnComboWindowOpened += OpenComboWindow;
        
        StartAttack(_currentAttackData);
    }

    public override void Execute()
    {
        foreach (var transition in _currentAttackData.ComboTransitions)
        {
            if (transition.InputButton.action.WasPressedThisFrame())
            {
                _nextComboAttack = transition.NextAttack;
                break; 
            }
        }
    
        if (_isComboWindowOpen && _nextComboAttack != null)
        {
            var attackToPlay = _nextComboAttack;
        
            _nextComboAttack = null;
            _isComboWindowOpen = false;
        
            StartAttack(attackToPlay);
        }
    }

    public override void Exit()
    {
        _animator.OnAttackAnimationFinished -= FinishAttack;
        _animator.OnComboWindowOpened -= OpenComboWindow;
        _animator.SetIsAttacking(false);
    }

    private void StartAttack(AttackSO attackData)
    {
        _attackStartTime = Time.time; 
        
        _movement.MovementSwitch(false);
        _currentAttackData = attackData;
        _nextComboAttack = null;
        _isComboWindowOpen = false;
        
        _animator.PlayAttackAnimation(attackData.AnimationClip);
        _animator.SetIsAttacking(true);
    }
    
    private void OpenComboWindow() => _isComboWindowOpen = true;
    
    private void FinishAttack()
    {
       
        if (Time.time - _attackStartTime < _animator.СrossFadeDuration) 
        {
            return;
        }

        _isComboWindowOpen = false;
        
        if (_characterController.isGrounded)
        {
            _stateMachine.ChangeState<IdleState>();
        }
        else
        {
            _stateMachine.ChangeState<FallingState>();
        }
        _movement.MovementSwitch(true); 
    }
}