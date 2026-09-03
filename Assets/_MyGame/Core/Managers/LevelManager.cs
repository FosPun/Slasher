using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{

    public Action OnRoundFinished;
    public Action<float> OnTimerChanged;
    [SerializeField] private float roundTime;

    public float CurrentRoundTime => _currentRoundTime;
    private float _currentRoundTime;
    private EnemySpawner _enemySpawner;
    private List<GameObject> _enemies;
    [SerializeField] private WaveSO _wave;
    
    [Inject]
    private void Construct(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
    }

    private void FixedUpdate()
    {
        DecreaseTimer();
    }

    private void DecreaseTimer()
    {
        if(_currentRoundTime <= 0) return;
        _currentRoundTime -= Time.fixedDeltaTime;
        
        OnTimerChanged?.Invoke(_currentRoundTime);
        
        if (_currentRoundTime <= 0)
        {
            OnRoundFinished?.Invoke();
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        StartRound(roundTime, _wave.AmountOfEnemiesToSpawn, _wave.EnemiesDataToSpawn);
    }

    private void StartRound(float roundTime, int enemiesAmount, EnemySO[] enemies)
    {
        _currentRoundTime = roundTime;
        _enemySpawner.SpawnRandomEnemies(enemiesAmount, enemies);
    }

    private void FinishRound()
    {
        
    }
}
