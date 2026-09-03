using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public Action<int> OnCoinsChanged;
    public int Coins => _coins;
    
    private int _coins = 0;


    private void OnEnable()
    {
        EventBus.Subscribe<CoinsChangeEvent>(ChangeCoins);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<CoinsChangeEvent>(ChangeCoins);
    }

    private void ChangeCoins(CoinsChangeEvent obj)
    {
        _coins += obj.Coins;
        OnCoinsChanged?.Invoke(_coins);
    }
}

