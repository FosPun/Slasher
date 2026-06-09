
using UnityEngine;
using Zenject;

public abstract class OnGroundState : PlayerState
{
    
    public override void Enter()
    {
        base.Enter();
        _animator.SetOnGroundBool(true);
        _movement.OnJump += ChangeToJumpState;
    }

    public override void Execute()
    {
        if (!_characterController.isGrounded)
        {
            _stateMachine.ChangeState<FallingState>();
        }
    }

    private void ChangeToJumpState()
    {
        _stateMachine.ChangeState<JumpingState>();
    }
    public override void Exit()
    {
        _animator.SetOnGroundBool(false);
        _movement.OnJump -= ChangeToJumpState;
    }
}

