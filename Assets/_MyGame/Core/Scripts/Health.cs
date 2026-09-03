using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action OnHealthChanged;
    public Action OnDamageTaken;
    public Action OnHealed;
    public Action OnDeath;
    
    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealthPoints;
    public bool IsDead => _currentHealthPoints <= 0;
    
    private int  _maxHealth;
    private int _currentHealthPoints;
    private bool _isDead = false;
    
    private void Awake()
    {
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
        if (_isDead || heal <= 0) return;
        _currentHealthPoints = Mathf.Min(_currentHealthPoints + heal, _maxHealth);
        OnHealthChanged?.Invoke();
        OnHealed?.Invoke();
    }
    private void Die()
    {
        _isDead = true;
        OnDeath?.Invoke();
    }

    public void SetMaxHealth(int maxHealth)
    {
        _maxHealth = maxHealth;
    }
    public void ChangeCurrentHealthPoints(int amount)
    {
        _currentHealthPoints += amount;
        OnHealthChanged?.Invoke();
    }
}
