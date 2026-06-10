using System.Collections;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using Zenject;

public class PlayerAnimator : MonoBehaviour
{
    
    [SerializeField] private string movingBoolName = "IsMoving";
    [SerializeField] private string airBoolName = "InAir";
    [SerializeField] private string onGroundBoolName = "OnGround";
    [SerializeField] private string idleBoolName = "IsIdle";
    [SerializeField] private string jumpBoolName = "IsJump";
    [SerializeField] private string jumpTriggerName = "Jump";
    [Inject] private Animator _animator;
    
    private PlayableGraph _graph;
    private AnimationPlayableOutput _animOutput;
    private AnimationClipPlayable _animClip;
    private Coroutine _coroutine;

    
    private void Awake()
    {
        _graph = PlayableGraph.Create("PlayableGraph");
        _graph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
        _animOutput = AnimationPlayableOutput.Create(_graph, "Animation", _animator);
    }

    public void PlayAttackAnimation(AttackSO attack)
    {
        if (_animClip.IsValid())
        {
            _animClip.Destroy();
        }
        _animClip = AnimationClipPlayable.Create(_graph,attack.AnimationClip);
        _animOutput.SetSourcePlayable(_animClip);
        _graph.Play();

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        _coroutine = StartCoroutine(TransitionToBaseAnimator(attack.AnimationClip.length));
    }

    private IEnumerator TransitionToBaseAnimator(float playableAnimClipLength)
    {
        yield return new WaitForSeconds(playableAnimClipLength);
        _graph.Stop();
    }
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

    private void OnDestroy()
    {
        if (_graph.IsValid())
        {
            _graph.Destroy();
        }
    }
}
