using System;
using TMPro;
using UnityEngine;
using Zenject;

public class SkillPointsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _skillPointsText;
    private SkillPointsManager _skillPointsManager;

    [Inject]
    public void Construct(SkillPointsManager skillPointsManager)
    {
        _skillPointsManager = skillPointsManager;
    }

    private void OnEnable()
    {
        _skillPointsManager.OnSkillPointsChanged += UpdateText;
    }

    private void OnDisable()
    {
        _skillPointsManager.OnSkillPointsChanged -= UpdateText;
    }

    private void UpdateText(int amount)
    {
        _skillPointsText.text = amount.ToString();
    }
}
