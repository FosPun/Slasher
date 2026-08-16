
namespace _MyGame.Player.Scripts.StateMachine
{
    public class AttackState : PlayerState
    {
        public override void Enter()
        {
            base.Enter();
            Combat.OnAttackFinish += StopAttacking;
            Movement.MovementSwitch(false);
            Animator.SetIsAttacking(true);
            
        }
        public override void Execute()
        {
            
        }
        public override void Exit()
        {
            Movement.MovementSwitch(true); 
            Animator.SetComboFinsihedTrigger();
            Animator.SetIsAttacking(false);
            Combat.OnAttackFinish -= StopAttacking;
        }
        private void StopAttacking()
        {
            if (CharacterController.isGrounded)
            {
                StateMachine.ChangeState<IdleState>();
            }
            else
            {
                StateMachine.ChangeState<FallingState>();
            }
        }
        
    }
}