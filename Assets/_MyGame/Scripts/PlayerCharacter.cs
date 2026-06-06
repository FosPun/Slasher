using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerCharacter : Character
{
    [HideInInspector] public PlayerStateMachine PlayerStateMachine;
    [HideInInspector] public PlayerMovement PlayerMovement;
    [HideInInspector] public PlayerAnimator PlayerAnimator;
    [HideInInspector] public CharacterController CharacterController;
    [HideInInspector] public PlayerInputHandler PlayerInputHandler;
    protected override void Initialize()
    {
        CharacterController = GetComponent<CharacterController>();
        PlayerAnimator = GetComponent<PlayerAnimator>();
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerInputHandler = GetComponent<PlayerInputHandler>();
        
        PlayerStateMachine = new PlayerStateMachine(this);
        PlayerStateMachine.Initialize(PlayerStateMachine.OnGroundState);
    }
    
    private void Update()
    {
        PlayerStateMachine.Execute();
    }
}
