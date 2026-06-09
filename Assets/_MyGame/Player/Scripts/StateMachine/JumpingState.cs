
public class JumpingState : InAirState
{
   public override void Enter()
   {
      base.Enter();
      _animator.SetJumpTrigger();
      _animator.SetIsJump(true);
         
   }

   public override void Execute()
   {
      base.Execute();
      if (_movement.Velocity.y <= 0)
      {
         _stateMachine.ChangeState<FallingState>();
      }
   }

   public override void Exit()
   {
      base.Exit();
      _animator.SetIsJump(false);
   }
}
