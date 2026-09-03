using System;
using UnityEngine;
using Zenject;

public class SkillTreeManager : MonoBehaviour
{
    private SkillPointsManager _skillPointsManager;
    public  AttackSO baseLightAttack;
    public  AttackSO baseHeavyAttack;
    [Inject]
    public void Construct(SkillPointsManager skillPointsManager)
    {
        _skillPointsManager = skillPointsManager;
    }

    private void Awake()
    {
        UnlockAttack(baseLightAttack);
        UnlockAttack(baseHeavyAttack);
       
    }


    public void UnlockAttack(AttackSO attackSo)
    {
        if (_skillPointsManager.SkillPoints < attackSo.cost) return;
        
        _skillPointsManager.ChangePoints(-attackSo.cost);
        ConfigDynamic.UnlockedAttacks.Add(attackSo);
    }
}
