using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action OnHealthChanged;
    public Action OnDamageTaken;
    public Action OnHealed;
    public Action OnDeath;

    public int CurrentHealth => _currentHealthPoints;
    public bool IsDead => _currentHealthPoints <= 0;
     
    [SerializeField] private int maxHealthPoints;
    
    private int _currentHealthPoints;
    private bool _isDead = false;

    private void Awake()
    {
        _currentHealthPoints = maxHealthPoints;
        OnHealthChanged?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if(_isDead ) return;
        ChangeCurrentHealthPoints(-damage);
        OnDamageTaken?.Invoke();
        if (_currentHealthPoints <= 0)
        {
            _currentHealthPoints = 0;
            Die();
        }
    }

    public void Heal(int heal)
    {
        if(_isDead) return;
        ChangeCurrentHealthPoints(heal);
        if (_currentHealthPoints >= maxHealthPoints)
        {
            _currentHealthPoints = maxHealthPoints;
        }
        OnHealed?.Invoke();
    }
    private void Die()
    {
        _isDead = true;
        OnDeath?.Invoke();
    }

    private void ChangeCurrentHealthPoints(int amount)
    {
        _currentHealthPoints += amount;
        OnHealthChanged?.Invoke();
    }
}
