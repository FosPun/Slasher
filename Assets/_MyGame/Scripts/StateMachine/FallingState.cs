using UnityEngine;
public class FallingState : InAirState
{
    public FallingState(PlayerAnimator animator, PlayerInputHandler input, StateMachine stateMachine, PlayerMovement character, CharacterController characterController) : base(animator, input, stateMachine, character, characterController)
    {
        
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
