using System;
using _MyGame.Player.Scripts;
using _MyGame.Player.Scripts.StateMachine;
using UnityEngine;
using Zenject;

public class PlayerCharacter : Character
{
    public StateMachine StateMachine => _stateMachine;
    private StateMachine _stateMachine;
    private PlayerAnimator _animator;
    private Combat _combat;
    private CharacterController _controller;
     
    [Inject]
    private void Construct(StateMachine stateMachine, PlayerAnimator animator, Combat combat, CharacterController controller)
    {
        _stateMachine = stateMachine;
        _animator = animator;
        _combat = combat;
        _controller = controller;
    }

    

    protected override void Initialize()
    {
        _stateMachine.Initialize<IdleState>();
    }
     
    private void Update() 
    {
        _stateMachine.Execute(); 
    }

    public void Attack(string name)
    {
        _stateMachine.ChangeState<AttackState>();
        _animator.CrossFadeAttack(name);
    }
    
}