
public class OnGroundState : IState
{

    private PlayerCharacter _playerCharacter;
    
    public OnGroundState(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter;
        
    }
    public void Enter()
    {
        _playerCharacter.PlayerAnimator.SetOnGroundBool(true);
        _playerCharacter.PlayerMovement.OnJump += _playerCharacter.PlayerAnimator.SetJumpTrigger;
    }

    public void Execute()
    {
        if (!_playerCharacter.CharacterController.isGrounded)
        {
            _playerCharacter.PlayerStateMachine.TransitionTo(_playerCharacter.PlayerStateMachine.InAirState);
        }

        if (_playerCharacter.PlayerInputHandler.MovementInput.sqrMagnitude > 0)
        {
            _playerCharacter.PlayerStateMachine.TransitionTo(_playerCharacter.PlayerStateMachine.MovingState);
        }
    }

    public void Exit()
    {
        _playerCharacter.PlayerAnimator.SetOnGroundBool(false);
        _playerCharacter.PlayerMovement.OnJump -= _playerCharacter.PlayerAnimator.SetJumpTrigger;
    }
}
