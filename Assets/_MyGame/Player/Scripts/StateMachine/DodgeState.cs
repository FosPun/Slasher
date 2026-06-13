using UnityEngine;

public class DodgeState : PlayerState
{
    private float _dodgeDuration;
    private float _dodgeDistance; 
    private AnimationCurve _dodgeCurve; 
    
    private float _timer;
    private Vector3 _dodgeDirection;
    private float _calculatedBaseSpeed; 

    public override void Enter()
    {
        base.Enter();
        
        _dodgeDuration = _playerCharacter.CharacteristicsSO.dodgeDuration;
        _dodgeDistance = _playerCharacter.CharacteristicsSO.dodgeDistance; 
        _dodgeCurve = _playerCharacter.CharacteristicsSO.dodgeCurve;      
        
        _animator.SetIsDodging(true);
        _timer = 0f;
        
        
        _calculatedBaseSpeed = _dodgeDuration > 0f ? _dodgeDistance / _dodgeDuration : 0f;
     
       
        if (_input.MovementInput.sqrMagnitude > 0.01f)
        {
            _dodgeDirection = new Vector3(_input.MovementInput.x, 0, _input.MovementInput.z).normalized;
            _movement.transform.rotation = Quaternion.LookRotation(_dodgeDirection);
        }
        else
        {
            _dodgeDirection = _movement.transform.forward; 
        }
        
        _movement.MovementSwitch(false); 
    }

    public override void Execute()
    {
        _timer += Time.deltaTime;
        
        float normalizedTime = _dodgeDuration > 0f ? _timer / _dodgeDuration : 1f;
        
        float curveMultiplier = _dodgeCurve?.Evaluate(normalizedTime) ?? 1f;
        
        _characterController.Move(_dodgeDirection * (_calculatedBaseSpeed * curveMultiplier * Time.deltaTime));

        if (_timer >= _dodgeDuration)
        {
            if (_input.MovementInput.sqrMagnitude > 0.01f)
            {
                _stateMachine.ChangeState<MovingState>();
            }
            else
            {
                _stateMachine.ChangeState<IdleState>();
            }
        }
    }

    public override void Exit()
    {
        _movement.MovementSwitch(true);
        _animator.SetIsDodging(false);
    }
}