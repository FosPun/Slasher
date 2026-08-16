using _MyGame.Player.Scripts;
using UnityEngine;
using Zenject;
    public abstract class PlayerState : IState
    {
        protected  PlayerAnimator Animator;
        protected  PlayerInputHandler Input;
        protected  StateMachine StateMachine;
        protected  PlayerMovement Movement;
        protected  CharacterController CharacterController;
        protected  PlayerCharacter PlayerCharacter;
        protected  Combat Combat;
        
    
        [Inject]
        protected void Construct
        (
            PlayerAnimator animator, 
            PlayerInputHandler input, 
            StateMachine stateMachine, 
            PlayerMovement character, 
            CharacterController characterController, 
            PlayerCharacter playerCharacter, 
            Combat combat
        )
        {
            Animator = animator;
            Input = input;
            StateMachine = stateMachine;
            Movement = character;
            CharacterController = characterController;
            PlayerCharacter = playerCharacter;
            Combat = combat;
        }

        public virtual void Enter()
        {
            Debug.Log(StateMachine.CurrentState);
        }

        public abstract void Execute();

        public abstract void Exit();
    
    }
