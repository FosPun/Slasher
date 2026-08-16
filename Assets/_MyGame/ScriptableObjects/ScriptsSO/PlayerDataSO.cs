using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Scriptable Objects/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    public HashSet<AttackSO> UnlockedAttacks { get; } = new();

    public AttackSO baseLightAttack;
    public AttackSO baseHeavyAttack;

    public bool IsUnlocked(AttackSO attackSo)
    {
        return UnlockedAttacks.Contains(attackSo);
    }
}
