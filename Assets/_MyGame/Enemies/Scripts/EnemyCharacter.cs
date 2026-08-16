using System;
using _MyGame.Player.Scripts;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Action = System.Action;

public class EnemyCharacter : Character
{
    public static Action<int> OnEnemyDeath;
    
    [SerializeField] private int rewardOnDeath = 5;
    private PlayerCharacter _player;
    private Health _health;
    private BehaviorGraphAgent _agent;
    private Animator _animator;
    private GroundChecker _groundChecker;
    private NavMeshAgent _navMeshAgent;
    
    
    [Inject]
    private void Construct(PlayerCharacter player, StateMachine stateMachine, Health health, BehaviorGraphAgent agent, Animator animator, GroundChecker groundChecker, NavMeshAgent navMeshAgent)
    {
        _player = player;
        _agent = agent;
        _health = health;
        _animator = animator;
        _groundChecker = groundChecker;
        _navMeshAgent = navMeshAgent;
        
        _agent.SetVariableValue("player", _player.gameObject.transform);
        _agent.SetVariableValue("animator", _animator);
    }

    private void FixedUpdate()
    {
        _agent.SetVariableValue("IsGrounded", _groundChecker.IsGrounded);
        if (!_navMeshAgent.isOnNavMesh || !_navMeshAgent.enabled)
        {
            _agent.SetVariableValue("IsGrounded", false);
        }
    }

    private void OnEnable()
    {
        _health.OnDamageTaken += HandleDamageTaken;
        _health.OnDeath += DieCharacter;

    }

    private void OnDisable()
    {
        _health.OnDamageTaken -= HandleDamageTaken;
        _health.OnDeath -= DieCharacter;
    }

    private void HandleDamageTaken()
    {
        
    }

    private void DieCharacter()
    {
        Destroy(gameObject);
        OnEnemyDeath.Invoke(rewardOnDeath);
    }
    protected override void Initialize()
    {
        
    }
}
