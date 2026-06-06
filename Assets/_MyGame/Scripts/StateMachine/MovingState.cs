
public class MovingState : IState
{
    private PlayerCharacter _playerCharacter;
    public MovingState(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter;
    }
    public void Enter()
    {
        _playerCharacter.PlayerAnimator.SetIsMoving(true);
    }

    public void Execute()
    {
        if (!_playerCharacter.CharacterController.isGrounded)
        {
            _playerCharacter.PlayerStateMachine.TransitionTo(_playerCharacter.PlayerStateMachine.InAirState);
        }
        if (_playerCharacter.PlayerInputHandler.MovementInput.sqrMagnitude <= 0)
        {
            _playerCharacter.PlayerStateMachine.TransitionTo(_playerCharacter.PlayerStateMachine.OnGroundState);
        }
        
    }

    public void Exit()
    {
        _playerCharacter.PlayerAnimator.SetIsMoving(false);
    }
}
