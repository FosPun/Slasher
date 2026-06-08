using Zenject;
using UnityEngine;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerCharacter _playerCharacter;
    
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerInputHandler _playerInputHandler;
    [SerializeField] private PlayerMovement _playerMovement;

    public override void InstallBindings()
    {
        //Components
        Container.BindInstance(_playerAnimator);
        Container.BindInstance(_characterController);
        Container.BindInstance(_playerInputHandler);
        Container.BindInstance(_playerMovement);

        //StateMachine
        Container.Bind<StateMachine>().AsSingle();

        // States for StateMachine
        Container.Bind<IdleState>().AsSingle();
        Container.Bind<MovingState>().AsSingle();
        Container.Bind<FallingState>().AsSingle();

        Container.BindInstance(_playerCharacter);
    }
}
