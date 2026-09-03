
using System;
using UnityEngine;
using Zenject;

public class PlayerCombo : MonoBehaviour
{
    public Combat Combat { get; private set; }

    private CombatAnimator _combatAnimator;

    private int _comboStep = 0;
    private bool _comboWindowOpened = false;
    private AttackInput? _bufferedInput;

    [Inject]
    public void Construct(Combat combat, CombatAnimator combatAnimator)
    {
        Combat = combat;
        _combatAnimator = combatAnimator;
    }
    
    private void OnEnable()
    {
        _combatAnimator.OnComboWindowOpened += OpenComboWindow;
        _combatAnimator.OnComboWindowClosed += CloseComboWindow;
        Combat.OnAttackFinished += ResetCombo;
    }

    private void OnDisable()
    {
        _combatAnimator.OnComboWindowOpened -= OpenComboWindow;
        _combatAnimator.OnComboWindowClosed -= CloseComboWindow;
        Combat.OnAttackFinished -= ResetCombo;
    }

    public bool TryProcessAttackInput(AttackInput input, AttackSO baseAttack)
    {
        if (!Combat.IsAttacking)
            return StartCombo(baseAttack);

        if (_comboWindowOpened)
        {
            var nextAttack = GetNextAttack(input);
            if (nextAttack != null && ConfigDynamic.IsUnlocked(nextAttack))
            {
                _comboStep++;
                Combat.ExecuteAttack(nextAttack);
                _comboWindowOpened = false;
                return true;
            }
        }
        else
        {
            _bufferedInput = input;
        }

        return false;
    }

    private bool StartCombo(AttackSO attack)
    {
        if (attack == null || !ConfigDynamic.IsUnlocked(attack)) return false;

        _comboStep = 1;
        Combat.ExecuteAttack(attack);
        return true;
    }

    private AttackSO GetNextAttack(AttackInput input)
    {
        if (Combat.CurrentActiveAttack == null) return null;
        return Combat.CurrentActiveAttack.transitions.Find(t => t.attackInput == input);
    }

    private void OpenComboWindow()
    {
        _comboWindowOpened = true;

        if (_bufferedInput.HasValue)
        {
            var input = _bufferedInput.Value;
            _bufferedInput = null;
            TryProcessAttackInput(input, null);
        }
    }

    private void CloseComboWindow()
    {
        _comboWindowOpened = false;
    }

    private void ResetCombo()
    {
        _comboStep = 0;
        _comboWindowOpened = false;
        _bufferedInput = null;
    }
}
