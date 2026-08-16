using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class BaseEffectHandler : MonoBehaviour
{
    protected Rigidbody _rigidbody;
    protected NavMeshAgent _navMeshAgent;
    protected GroundChecker _groundChecker;
    protected BehaviorGraphAgent _behaviorGraphAgent;
    
    [Inject]
    private void Construct(Rigidbody rigidbody, NavMeshAgent navMeshAgent, GroundChecker groundChecker, BehaviorGraphAgent behaviorGraphAgent)
    {
        _rigidbody = rigidbody;
        _navMeshAgent = navMeshAgent;
        _groundChecker = groundChecker;
        _behaviorGraphAgent = behaviorGraphAgent;
    }

    protected void DisableAgent()
    {
        if (_navMeshAgent != null && _navMeshAgent.enabled)
        {
            _navMeshAgent.enabled = false;
            _rigidbody.isKinematic = false;
        }
    }

    protected void EnableAgent()
    {
        if (_navMeshAgent != null && !_navMeshAgent.enabled)
        {
            if (NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 2.0f, NavMesh.AllAreas))
            {
                _navMeshAgent.Warp(hit.position);
            }
            
            _behaviorGraphAgent.Restart();
            _navMeshAgent.enabled = true;
            _rigidbody.isKinematic = true;

        }
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (_groundChecker.IsGrounded)
        {
            EnableAgent();
        }
    }*/
}
