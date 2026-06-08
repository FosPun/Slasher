
using UnityEngine;

public class MovingState : OnGroundState
{
    public MovingState(PlayerAnimator animator, PlayerInputHandler input, StateMachine stateMachine, PlayerMovement character, CharacterController characterController) : base(animator, input, stateMachine, character, characterController)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        _animator.SetIsMoving(true);
        
    }

    public override void Execute()
    {
        base.Execute();
        if (_input.MovementInput.sqrMagnitude <= 0.01f)
        {
            _stateMachine.ChangeState<IdleState>();
        }
    }

    public override void Exit()
    {
        base.Exit();
        _animator.SetIsMoving(false);
    }
}
