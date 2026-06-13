
using UnityEngine;
using Zenject;

public abstract class PlayerState : IState
{
    protected  PlayerAnimator _animator;
    protected  PlayerInputHandler _input;
    protected  StateMachine _stateMachine;
    protected  PlayerMovement _movement;
    protected  CharacterController _characterController;
    protected  PlayerCharacter _playerCharacter;
    
    [Inject]
    protected void Construct(PlayerAnimator animator, PlayerInputHandler input, StateMachine stateMachine, PlayerMovement character, CharacterController characterController, PlayerCharacter playerCharacter)
    {
        _animator = animator;
        _input = input;
        _stateMachine = stateMachine;
        _movement = character;
        _characterController = characterController;
        _playerCharacter = playerCharacter;
    }

    public virtual void Enter()
    {
        Debug.Log(_stateMachine.CurrentState);
    }

    public abstract void Execute();

    public abstract void Exit();
    
}
