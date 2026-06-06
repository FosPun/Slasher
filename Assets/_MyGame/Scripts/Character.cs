using UnityEngine;

public abstract class Character: MonoBehaviour
{
    [SerializeField] private CharacteristicsSO _characteristicsSO;
    public float MovementSpeed{get; private set;}
    public float AttackSpeed{get; private set;}
    public float Health{get;private set;}
    public float Damage{get; private set;}

    protected abstract void Initialize();


    protected void Awake()
    {
        SetAttributes();
        Initialize();
    }

    private void SetAttributes()
    {
        MovementSpeed = _characteristicsSO.movementSpeed;
        AttackSpeed = _characteristicsSO.attackSpeed;
        Health = _characteristicsSO.health;
        Damage = _characteristicsSO.damage;
    }
}
