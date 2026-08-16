using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{

    public Action OnRoundFinished;
    [SerializeField] private float roundTime;

    public float CurrentRoundTime => _currentRoundTime;
    private float _currentRoundTime;
    private EnemySpawner _enemySpawner;
    private List<GameObject> _enemies;
    
    [Inject]
    private void Construct(EnemySpawner enemySpawner)
    {
        _enemySpawner = enemySpawner;
    }

    private void FixedUpdate()
    {
        _currentRoundTime -= Time.fixedDeltaTime;
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
        StartRound(roundTime, Random.Range(1, 10));
    }

    private void StartRound(float roundTime, int enemiesAmount)
    {
        _currentRoundTime = roundTime;
        _enemySpawner.SpawnRandomEnemies(enemiesAmount);
    }

    private void FinishRound()
    {
        
    }
}
