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
    public override void InstallBindings()
    {
        Container.BindInstance(health);
        Container.BindInstance(rigidbody);
        Container.BindInstance(navMeshAgent);
        Container.BindInstance(groundChecker);
        Container.BindInstance(agent);
        Container.BindInstance(animator);
        
        Container.Bind<StateMachine>().AsCached();
    }
}
