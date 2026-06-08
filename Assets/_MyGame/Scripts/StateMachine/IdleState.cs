using UnityEngine;

public class IdleState : OnGroundState
{
 
    public IdleState(PlayerAnimator animator, PlayerInputHandler input, StateMachine stateMachine, PlayerMovement character, CharacterController characterController) : base(animator, input, stateMachine, character, characterController)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        _animator.SetIsIdle(true);
    }

    public override void Execute()
    {
        base.Execute();
        if (_input.MovementInput.sqrMagnitude > 0)
        {
            _stateMachine.ChangeState<MovingState>();
        }
    }

    public override void Exit()
    {
        base.Exit();
        _animator.SetIsIdle(false);
    }
}
