using UnityEngine;

public abstract class InAirState : IState
{

    protected readonly PlayerAnimator _animator;
    protected readonly PlayerInputHandler _input;
    protected readonly StateMachine _stateMachine;
    protected readonly PlayerMovement _movement;
    protected readonly CharacterController _characterController;
    
    protected InAirState(PlayerAnimator animator, PlayerInputHandler input, StateMachine stateMachine, PlayerMovement character,CharacterController characterController)
    {
        _animator = animator;
        _input = input;
        _stateMachine = stateMachine;
        _movement = character;
        _characterController = characterController;
    }
    public virtual void Enter()
    {
        _animator.SetInAir(true);
    }

    public virtual void Execute()
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

    public virtual void Exit()
    {
        _animator.SetInAir(false);
    }
}
