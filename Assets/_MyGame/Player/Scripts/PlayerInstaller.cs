using _MyGame.Player.Scripts.StateMachine;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _MyGame.Player.Scripts
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerCharacter playerCharacter;
    
        [SerializeField] private PlayerAnimator playerAnimator;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private PlayerInputHandler playerInputHandler;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Animator animator;
        [SerializeField] private Combat combat;

        public override void InstallBindings()
        {
            //Components
            Container.BindInstance(animator);
            Container.BindInstance(playerAnimator);
            Container.BindInstance(characterController);
            Container.BindInstance(playerInputHandler);
            Container.BindInstance(playerMovement);
            Container.BindInstance(combat);

            //StateMachine
            Container.Bind<global::StateMachine>().AsCached();

            // States for StateMachine
            Container.Bind<IState>().To<IdleState>().AsSingle();
            Container.Bind<IState>().To<MovingState>().AsSingle();
            Container.Bind<IState>().To<FallingState>().AsSingle();
            Container.Bind<IState>().To<JumpingState>().AsSingle();
            Container.Bind<IState>().To<AttackState>().AsSingle();
            Container.Bind<IState>().To<DodgeState>().AsSingle();

        }
    }
}
