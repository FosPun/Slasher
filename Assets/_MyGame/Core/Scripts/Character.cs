
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Character: MonoBehaviour
{
    public CharacteristicsSO CharacteristicsSO;
    public float MovementSpeed => CharacteristicsSO.movementSpeed;
    public float AttackSpeed => CharacteristicsSO.attackSpeed;
    public float Health => CharacteristicsSO.health;
    public float Damage => CharacteristicsSO.damage;

    protected abstract void Initialize();
    
    private void Start()
    {
        Initialize();
    }
}
