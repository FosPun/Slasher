using System;
using UnityEngine;

public class SkillPointsManager : MonoBehaviour
{
    public Action<int> OnSkillPointsChanged;
    public int SkillPoints => _skillPoints;
    
    private int _skillPoints = 0;
    
    public void ChangePoints(int amount)
    {
        _skillPoints += amount;
        OnSkillPointsChanged?.Invoke(_skillPoints);
    }
}
