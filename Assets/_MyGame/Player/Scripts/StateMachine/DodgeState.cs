using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

    public class DodgeState : PlayerState
    {
        private float _dodgeDuration;
        private float _dodgeDistance; 
        private AnimationCurve _dodgeCurve; 
    
        private Vector3 _dodgeDirection;
        private float _calculatedBaseSpeed; 
        
        private CancellationTokenSource _cancellationTokenSource;

        public override void Enter()
        {
            base.Enter();
        
            _dodgeDuration = PlayerCharacter.CharacteristicsSo.dodgeDuration;
            _dodgeDistance = PlayerCharacter.CharacteristicsSo.dodgeDistance; 
            _dodgeCurve = PlayerCharacter.CharacteristicsSo.dodgeCurve;      
        
            Animator.SetIsDodging(true);
        
            _calculatedBaseSpeed = _dodgeDuration > 0f ? _dodgeDistance / _dodgeDuration : 0f;
     
            if (Input.MovementInput.sqrMagnitude > 0.01f)
            {
                _dodgeDirection = new Vector3(Input.MovementInput.x, 0, Input.MovementInput.z).normalized;
                Movement.transform.rotation = Quaternion.LookRotation(_dodgeDirection);
            }
            else
            {
                _dodgeDirection = Movement.transform.forward; 
            }
        
            Movement.MovementSwitch(false); 
            
            _cancellationTokenSource = new CancellationTokenSource();
            
            
            PerformDodgeAsync(_cancellationTokenSource.Token).Forget();
        }

        public override void Execute()
        {
            
        }

        private async UniTaskVoid PerformDodgeAsync(CancellationToken token)
        {
            float timer = 0f;

            while (timer < _dodgeDuration)
            {
                timer += Time.deltaTime;
                
                float normalizedTime = _dodgeDuration > 0f ? timer / _dodgeDuration : 1f;
                float curveMultiplier = _dodgeCurve?.Evaluate(normalizedTime) ?? 1f;
            
                CharacterController.Move(_dodgeDirection * (_calculatedBaseSpeed * curveMultiplier * Time.deltaTime));
                
                await UniTask.Yield(PlayerLoopTiming.Update, token);
            }

            if (Input.MovementInput.sqrMagnitude > 0.01f)
            {
                StateMachine.ChangeState<MovingState>();
            }
            else
            {
                StateMachine.ChangeState<IdleState>();
            }
        }
        
        public override void Exit()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;

            Movement.MovementSwitch(true);
            Animator.SetIsDodging(false);
        }
    }
