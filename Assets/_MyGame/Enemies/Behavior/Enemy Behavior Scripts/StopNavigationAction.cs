using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Stop Navigation", story: "[Agent] reset path", category: "Action", id: "3ae145f05e24607811817840ff387df2")]
public partial class StopNavigationAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMeshAgent> Agent;
    private NavMeshAgent _navMeshAgent => Agent?.Value as NavMeshAgent;
    protected override Status OnStart()
    {
        _navMeshAgent.ResetPath();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        
        return Status.Success;
        
    }

    protected override void OnEnd()
    {
    }
}

