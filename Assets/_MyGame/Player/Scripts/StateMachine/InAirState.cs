using UnityEngine;
using Zenject;

public abstract class InAirState : PlayerState
{
    
    public override void Enter()
    {
        base.Enter();
        _animator.SetInAir(true);
    }

    public override void Execute()
    {
        if (_characterController.isGrounded && _input.MovementInput.sqrMagnitude > 0)
        {
            _stateMachine.ChangeState<MovingState>();
        }
        else if (_characterController.isGrounded)
        {
            _stateMachine.ChangeState<IdleState>();
        }
    }

    public override void Exit()
    {
        _animator.SetInAir(false);
    }
}
