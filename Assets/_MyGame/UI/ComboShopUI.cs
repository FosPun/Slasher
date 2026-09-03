using System;
using TMPro;
using UnityEngine;
using Zenject;

public class ComboShopUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _SkillPointsText;
    private SkillPointsManager _skillPointsManager;
    

    [Inject]
    private void Construct(SkillPointsManager skillPointsManager)
    {
        _skillPointsManager = skillPointsManager;
    }

    private void Awake()
    {
        _skillPointsManager.ChangePoints(50);
        _SkillPointsText.text = _skillPointsManager.SkillPoints.ToString();
    }
}
