
using UnityEngine;
using Zenject;

public class PlayerCharacter : Character
{
    private StateMachine _stateMachine;
     [Inject]
     private void Construct(StateMachine stateMachine)
     {
         _stateMachine = stateMachine;
     }
    protected override void Initialize()
    {
        _stateMachine.Initialize<IdleState>();
    }
    private void Update()
    {
        _stateMachine.Execute();
    }
}
