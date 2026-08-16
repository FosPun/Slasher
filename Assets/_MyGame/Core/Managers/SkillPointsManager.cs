using System;
using UnityEngine;

public class SkillPointsManager : MonoBehaviour
{
    public Action OnSkillPointsChanged;
    public int SkillPoints => _skillPoints;
    
    private int _skillPoints = 0;


    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    public void AddPoints(int amount)
    {
        _skillPoints += amount;
        Debug.Log("Coins: " + _skillPoints);
    }
}
