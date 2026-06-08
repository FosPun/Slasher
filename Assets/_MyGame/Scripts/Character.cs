using System;
using UnityEngine;

public abstract class Character: MonoBehaviour
{
    [SerializeField] private CharacteristicsSO _characteristicsSO;
    public float MovementSpeed => _characteristicsSO.movementSpeed;
    public float AttackSpeed => _characteristicsSO.attackSpeed;
    public float Health => _characteristicsSO.health;
    public float Damage => _characteristicsSO.damage;

    protected abstract void Initialize();
    
    private void Start()
    {
        Initialize();
    }
}
