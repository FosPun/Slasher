namespace _MyGame.Player.Scripts.StateMachine
{
    public abstract class InAirState : PlayerState
    {
    
        public override void Enter()
        {
            base.Enter();
            Animator.SetInAir(true);
        }

        public override void Execute()
        {
            if (CharacterController.isGrounded && Input.MovementInput.sqrMagnitude > 0)
            {
                StateMachine.ChangeState<MovingState>();
            }
            else if (CharacterController.isGrounded)
            {
                StateMachine.ChangeState<IdleState>();
            }
        }

        public override void Exit()
        {
            Animator.SetInAir(false);
        }
    }
}
