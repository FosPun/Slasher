using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private IInstantiator _instantiator;
    [SerializeField] private Collider _collider;

    [Inject]
    private void Construct(IInstantiator instantiator)
    {
        _instantiator = instantiator;
    }

    public void SpawnRandomEnemies(int amountEnemies , EnemySO[] enemiesData)
    {
        for (int i = 0; i < amountEnemies; i++)
        {
            SpawnEnemy(enemiesData[Random.Range(0, enemiesData.Length)].prefab);
        }
    }
    private void SpawnEnemy(GameObject enemy)
    {
        Vector3 spawnPosition = new Vector3(Random.Range(_collider.bounds.min.x, _collider.bounds.max.x), 0, Random.Range(_collider.bounds.min.z, _collider.bounds.max.z));
        _instantiator.InstantiatePrefab(enemy, spawnPosition, Quaternion.identity, null);
    }
}
