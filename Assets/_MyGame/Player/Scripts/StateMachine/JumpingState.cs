
   public class JumpingState : InAirState
   {
      public override void Enter()
      {
         base.Enter();
         Animator.SetJumpTrigger();
         Animator.SetIsJump(true);
         
      }

      public override void Execute()
      {
         base.Execute();
         if (Movement.Velocity.y <= 0)
         {
            StateMachine.ChangeState<FallingState>();
         }
      }

      public override void Exit()
      {
         base.Exit();
         Animator.SetIsJump(false);
      }
   }

