using System;
using System.Collections.Generic;
using UnityEngine;

public static class ConfigDynamic
{
    public static PlayerData PlayerData = new();
    
    public static bool IsGamePause = false;
    public static bool IsGameOver = false;
    
    public static HashSet<AttackSO> UnlockedAttacks { get; } = new();
    
    public static bool IsUnlocked(AttackSO attackSo)
    {
        return UnlockedAttacks.Contains(attackSo);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    public static void ResetData()
    {
        PlayerData = new();
        IsGamePause = false;
        IsGameOver = false;
        UnlockedAttacks.Clear();
    }
}


[Serializable]
public class PlayerData
{  
    public float volumeMusic = 0.5f;
    public float volumeSound = 0.5f;
}