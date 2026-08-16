namespace _MyGame.Player.Scripts.StateMachine
{
    public abstract class OnGroundState : PlayerState
    {
    
        public override void Enter()
        {
            base.Enter();
            Animator.SetOnGroundBool(true);
            Movement.OnJump += ChangeToJumpState;
            Input.OnDodgeInput += ChangeToDodge;
        }

        public override void Execute()
        {
            if (!CharacterController.isGrounded)
            {
                StateMachine.ChangeState<FallingState>();
            }
        }

        private void ChangeToDodge()
        {
            if (CharacterController.isGrounded)
            {
                StateMachine.ChangeState<DodgeState>();
            }
        }

        private void ChangeToJumpState()
        {
            StateMachine.ChangeState<JumpingState>();
        }
        public override void Exit()
        {
            Animator.SetOnGroundBool(false);
            Movement.OnJump -= ChangeToJumpState;
            Input.OnDodgeInput -= ChangeToDodge;
        }
    }
}

