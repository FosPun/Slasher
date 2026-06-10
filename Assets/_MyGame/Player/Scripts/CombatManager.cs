using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using Zenject;

public class CombatManager : MonoBehaviour
{
    [Inject] PlayerInputHandler _playerInputHandler;
    [Inject] PlayerAnimator _playerAnimator;
    public AttackSO CurrentAttack;
    [SerializeField] private AttackSO LightStart;
    [SerializeField] private AttackSO HeavyStart;
    
    private void OnEnable()
    {
        _playerInputHandler.OnLightInput += Execute;
        _playerInputHandler.OnHeavyInput += Execute2;
    }

    private void Execute()
    {
        _playerAnimator.PlayAttackAnimation(LightStart);
    }

    private void Execute2()
    {
        _playerAnimator.PlayAttackAnimation(HeavyStart);

    }
    private void OnDisable()
    { 
        _playerInputHandler.OnLightInput -= Execute;
        _playerInputHandler.OnHeavyInput -= Execute2;

    }
}
