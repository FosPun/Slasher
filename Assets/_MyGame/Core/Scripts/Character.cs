using UnityEngine;
using Zenject;

public abstract class Character : MonoBehaviour
{
    public CharacteristicsSO CharacteristicsSo{get; private set;}
    public Animator Animator {get; private set;}
    public float MovementSpeed => CharacteristicsSo.movementSpeed;
    public float AttackSpeed => CharacteristicsSo.attackSpeed;
    public int Health => CharacteristicsSo.health;
    public int MaxHealth => CharacteristicsSo.maxHealth;
    public float Damage => CharacteristicsSo.damage;
    
    protected Health _health;


    [Inject]
    private void Construct(CharacteristicsSO characteristicsSo, Health health, Animator animator)
    {
        Animator = animator;
        CharacteristicsSo = characteristicsSo;
        _health = health;
    }

    protected abstract void Initialize();
    private void Start()
    {
        Initialize();
        _health.SetMaxHealth(MaxHealth);
        _health.ChangeCurrentHealthPoints(Health);
    }
}
