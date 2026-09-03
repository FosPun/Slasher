using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] private Health health;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private BehaviorGraphAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private Character character;
    [SerializeField] private CharacteristicsSO characteristics;
    [SerializeField] private CombatAnimator combatAnimator;
    [SerializeField] private AttackSO baseAttackSo;
    [SerializeField] private Combat combat;
    [SerializeField] private StatusEffectController statusEffectController;
    public override void InstallBindings()
    {
        Container.BindInstance(rigidbody);
        Container.BindInstance(navMeshAgent);
        Container.BindInstance(groundChecker);
        Container.BindInstance(agent);
        Container.BindInstance(animator);
        Container.BindInstance(character);
        Container.BindInstance(characteristics);
        Container.BindInstance(health);
        Container.BindInstance(combatAnimator);
        Container.BindInstance(baseAttackSo);
        Container.BindInstance(combat);
        Container.BindInstance(statusEffectController);
    }
}
