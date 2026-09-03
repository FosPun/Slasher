public class AttackState : PlayerState
    {
        public override void Enter()
        {
            base.Enter();
            Combat.OnAttackFinished += StopAttacking;
            Movement.MovementSwitch(false);
            Animator.SetIsAttacking(true);
            
        }
        public override void Execute()
        {
            
        }
        public override void Exit()
        {
            Movement.MovementSwitch(true); 
            Animator.SetComboFinishedTrigger();
            Animator.SetIsAttacking(false);
            Combat.OnAttackFinished -= StopAttacking;
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