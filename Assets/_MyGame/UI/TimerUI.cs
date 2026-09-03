using System;
using TMPro;
using UnityEngine;
using Zenject;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [Inject] private LevelManager _levelManager;

    private void OnEnable()
    {
        _levelManager.OnTimerChanged += UpdateText;
    }

    private void OnDisable()
    {
        _levelManager.OnTimerChanged -= UpdateText;

    }

    private void UpdateText(float time)
    {
        timerText.text = $"{time:0}";
    }
}
