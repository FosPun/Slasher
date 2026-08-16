using System;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public Action OnCoinsChanged;
    public int Coins => _coins;
    
    private int _coins = 0;


    private void OnEnable()
    {
        EnemyCharacter.OnEnemyDeath += AddCoins;
    }

    private void OnDisable()
    {
        EnemyCharacter.OnEnemyDeath -= AddCoins;
    }

    public void AddCoins(int amount)
    {
        _coins += amount;
        Debug.Log("Coins: " + _coins);
    }
}

