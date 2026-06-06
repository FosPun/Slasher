public class InAirState : IState
{

    private PlayerCharacter _playerCharacter;
    
    public InAirState(PlayerCharacter playerCharacter)
    {
        _playerCharacter = playerCharacter; 
    }
    
    public void Enter()
    {
        _playerCharacter.PlayerAnimator.SetInAir(true);
    }

    public void Execute()
    {
        if (_playerCharacter.CharacterController.isGrounded)
        {
            _playerCharacter.PlayerStateMachine.TransitionTo(_playerCharacter.PlayerStateMachine.OnGroundState);
        }
    }

    public void Exit()
    {
        _playerCharacter.PlayerAnimator.SetInAir(false);
    }
}
