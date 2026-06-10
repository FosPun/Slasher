using Zenject;
using UnityEngine;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerCharacter _playerCharacter;
    
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerInputHandler _playerInputHandler;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Animator _animator;

    public override void InstallBindings()
    {
        //Components
        Container.BindInstance(_animator);
        Container.BindInstance(_playerAnimator);
        Container.BindInstance(_characterController);
        Container.BindInstance(_playerInputHandler);
        Container.BindInstance(_playerMovement);

        //StateMachine
        Container.Bind<StateMachine>().AsSingle();

        // States for StateMachine
        Container.Bind<IState>().To<IdleState>().AsSingle();
        Container.Bind<IState>().To<MovingState>().AsSingle();
        Container.Bind<IState>().To<FallingState>().AsSingle();
        Container.Bind<IState>().To<JumpingState>().AsSingle();

        Container.BindInstance(_playerCharacter);
    }
}
