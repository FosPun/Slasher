using System;
using System.Collections;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyCharacter : Character, IImpactable
{
    
    
    [SerializeField] private int rewardOnDeath = 5;
    private PlayerCharacter _player;
    private BehaviorGraphAgent _agent;
    private Animator _animator;
    private GroundChecker _groundChecker;
    private NavMeshAgent _navMeshAgent;
    private Combat _combat;
    private AttackSO _attackSo;
    private Rigidbody _rigidbody;
    
    private Coroutine _impactCoroutine;
    
    private const float ImpactDuration = 1;
    
    [Inject]
    private void Construct(AttackSO attackSo ,Combat combat ,PlayerCharacter player, BehaviorGraphAgent agent, Animator animator, GroundChecker groundChecker, NavMeshAgent navMeshAgent, Rigidbody rigidbody)
    {
        _player = player;
        _agent = agent;
        _animator = animator;
        _groundChecker = groundChecker;
        _navMeshAgent = navMeshAgent;
        _combat = combat;
        _attackSo = attackSo;
        _rigidbody = rigidbody;
    }

    private void Awake()
    {
        _agent.SetVariableValue("Combat", _combat);
        _agent.SetVariableValue("player", _player.gameObject.transform);
        _agent.SetVariableValue("animator", _animator);
        _agent.SetVariableValue("BaseAttack", _attackSo);
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
        EventBus.Publish(new CoinsChangeEvent(rewardOnDeath));
    }

    protected override void Initialize()
    {
        
    }
    
    public void ApplyImpact(Vector3 totalForce)
    {
        if (_health.IsDead) return;
        if (_impactCoroutine != null)
            StopCoroutine(_impactCoroutine);
        _impactCoroutine = StartCoroutine(ImpactRoutine(totalForce));
    }
    
    private IEnumerator ImpactRoutine(Vector3 force)
    {
        if (_navMeshAgent.enabled)
        {
            _navMeshAgent.enabled = false;
            _rigidbody.isKinematic = false;
        }
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.AddForce(force, ForceMode.Impulse);
        yield return new WaitForSeconds(ImpactDuration);
        while (!_groundChecker.IsGrounded)
        {
            yield return null;
        }
        if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 2.0f, NavMesh.AllAreas))
        {
            _navMeshAgent.Warp(hit.position);
        }
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.isKinematic = true;
        _navMeshAgent.enabled = true;
        _agent.Restart();
        _impactCoroutine = null;
    }

}
