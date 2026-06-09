using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    
    [SerializeField] private string movingBoolName = "IsMoving";
    [SerializeField] private string airBoolName = "InAir";
    [SerializeField] private string onGroundBoolName = "OnGround";
    [SerializeField] private string idleBoolName = "IsIdle";
    [SerializeField] private string jumpBoolName = "IsJump";
    [SerializeField] private string jumpTriggerName = "Jump";
    [SerializeField] private Animator _animator;
    public void SetIsMoving(bool state)
    {
        _animator.SetBool(movingBoolName, state);
    }
    public void SetIsIdle(bool state)
    {
        _animator.SetBool(idleBoolName, state);
    }
    public void SetInAir(bool state)
    {
        _animator.SetBool(airBoolName, state);
    }
    public void SetOnGroundBool(bool state)
    {
        _animator.SetBool(onGroundBoolName, state);
    }

    public void SetIsJump(bool state)
    {
        _animator.SetBool(jumpBoolName, state);
    }
    public void SetJumpTrigger()
    {
        _animator.SetTrigger(jumpTriggerName);
    }
}
