using UnityEngine;
using Zenject;
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Character playerCharacter;
        [SerializeField] private CharacteristicsSO characteristics;
        [SerializeField] private PlayerAnimator playerAnimator;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private PlayerInputHandler playerInputHandler;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private Animator animator;
        [SerializeField] private Health health;
        [SerializeField] private Combat combat;
        [SerializeField] private PlayerCombo playerCombo;
        [SerializeField] private CombatAnimator combatAnimator;

        public override void InstallBindings()
        {
            //Components
            Container.BindInstance(animator);
            Container.BindInstance(playerAnimator);
            Container.BindInstance(characterController);
            Container.BindInstance(playerInputHandler);
            Container.BindInstance(playerMovement);
            Container.BindInstance(combat);
            Container.BindInstance(characteristics);
            Container.BindInstance(health);
            Container.BindInstance(playerCharacter);
            Container.BindInstance(combatAnimator);
            Container.BindInstance(playerCombo);

            //StateMachine
            Container.Bind<StateMachine>().AsCached();

            // States for StateMachine
            Container.Bind<IState>().To<IdleState>().AsSingle();
            Container.Bind<IState>().To<MovingState>().AsSingle();
            Container.Bind<IState>().To<FallingState>().AsSingle();
            Container.Bind<IState>().To<JumpingState>().AsSingle();
            Container.Bind<IState>().To<AttackState>().AsSingle();
            Container.Bind<IState>().To<DodgeState>().AsSingle();

        }
    }

