namespace _MyGame.Player.Scripts.StateMachine
{
    public class IdleState : OnGroundState
    {
    
        public override void Enter()
        {
            base.Enter();
            Animator.SetIsIdle(true);
        }

        public override void Execute()
        {
            base.Execute();
            if (Input.MovementInput.sqrMagnitude > 0)
            {
                StateMachine.ChangeState<MovingState>();
            }
        }

        public override void Exit()
        {
            base.Exit();
            Animator.SetIsIdle(false);
        }
    }
}
