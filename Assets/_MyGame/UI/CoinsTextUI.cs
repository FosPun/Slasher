using System;
using TMPro;
using UnityEngine;
using Zenject;

public class CoinsTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsText;
    private CoinManager _coinManager;

    [Inject]
    private void Construct(CoinManager coinManager)
    {
        _coinManager = coinManager;
    }

    private void OnEnable()
    {
        _coinManager.OnCoinsChanged += UpdateText;
    }

    private void OnDisable()
    {
        _coinManager.OnCoinsChanged -= UpdateText;

    }

    private void UpdateText(int coins)
    {
        _coinsText.text = coins.ToString();
    }
}
