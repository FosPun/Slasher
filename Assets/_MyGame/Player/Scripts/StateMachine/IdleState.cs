using UnityEngine;

public class IdleState : OnGroundState
{
    
    public override void Enter()
    {
        base.Enter();
        _animator.SetIsIdle(true);
    }

    public override void Execute()
    {
        base.Execute();
        if (_input.MovementInput.sqrMagnitude > 0)
        {
            _stateMachine.ChangeState<MovingState>();
        }
    }

    public override void Exit()
    {
        base.Exit();
        _animator.SetIsIdle(false);
    }
}
