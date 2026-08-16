using System;
using UnityEngine;
using Zenject;

public class SkillTreeManager : MonoBehaviour
{
    private SkillPointsManager _skillPointsManager;
    private PlayerDataSO _playerData;

    [Inject]
    public void Construct(SkillPointsManager skillPointsManager, PlayerDataSO playerData)
    {
        _skillPointsManager = skillPointsManager;
        _playerData = playerData;
    }

    private void Start()
    {
        UnlockAttack(_playerData.baseLightAttack);
        UnlockAttack(_playerData.baseHeavyAttack);
       
    }

    public void UnlockAttack(AttackSO attackSo)
    {
        if (_skillPointsManager.SkillPoints >= attackSo.cost)
        {
            _playerData.UnlockedAttacks.Add(attackSo);
        }
    }
}
