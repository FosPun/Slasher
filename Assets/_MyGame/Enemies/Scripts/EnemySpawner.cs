using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private IInstantiator _instantiator;
    [SerializeField] private EnemySO[] _enemies;
    [SerializeField] private Collider _collider;

    [Inject]
    private void Construct(IInstantiator instantiator)
    {
        _instantiator = instantiator;
    }

    public void SpawnRandomEnemies(int amountEnemies)
    {
        for (int i = 0; i < amountEnemies; i++)
        {
            SpawnEnemy(_enemies[Random.Range(0, _enemies.Length)].prefab);
        }
    }
    private void SpawnEnemy(GameObject enemy)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(_collider.bounds.min.x, _collider.bounds.max.x), 0, Random.Range(_collider.bounds.min.z, _collider.bounds.max.z));
        _instantiator.InstantiatePrefab(enemy, spawnPosition, Quaternion.identity, null);
    }
}
