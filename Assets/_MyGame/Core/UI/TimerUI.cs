using System;
using TMPro;
using UnityEngine;
using Zenject;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [Inject] private LevelManager _levelManager;

    private void FixedUpdate()
    {
        timerText.text = $"{_levelManager.CurrentRoundTime:0}";
    }
}
