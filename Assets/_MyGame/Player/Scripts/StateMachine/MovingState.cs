
namespace _MyGame.Player.Scripts.StateMachine
{
    public class MovingState : OnGroundState
    {
    
        public override void Enter()
        {
            base.Enter();
            Animator.SetIsMoving(true);
        
        }

        public override void Execute()
        {
            base.Execute();
            if (Input.MovementInput.sqrMagnitude <= 0.01f)
            {
                StateMachine.ChangeState<IdleState>();
            }
        }

        public override void Exit()
        {
            base.Exit();
            Animator.SetIsMoving(false);
        }
    }
}
