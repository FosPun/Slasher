
using UnityEngine;

public abstract class OnGroundState : IState
{

    protected readonly PlayerAnimator _animator;
    protected readonly PlayerInputHandler _input;
    protected readonly StateMachine _stateMachine;
    protected readonly PlayerMovement _movement;
    protected readonly CharacterController _characterController;
    
    protected OnGroundState(PlayerAnimator animator, PlayerInputHandler input, StateMachine stateMachine, PlayerMovement character,CharacterController characterController)
    {
        _animator = animator;
        _input = input;
        _stateMachine = stateMachine;
        _movement = character;
        _characterController = characterController;
    }
    public virtual void Enter()
    {
        _animator.SetOnGroundBool(true);
    }

    public virtual void Execute()
    {
        if (!_characterController.isGrounded)
        {
            _stateMachine.ChangeState<FallingState>();
        }
    }

    public virtual void Exit()
    {
        _animator.SetOnGroundBool(false);
        _movement.OnJump -= _animator.SetJumpTrigger;
    }
}
