using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StatusEffectController : MonoBehaviour
{
    private readonly List<StatusEffect> _activeEffects = new();
    private Character _character;


    [Inject]
    private void Construct(Character character)
    {
        _character = character;
    }

    public void ApplyEffect(StatusEffect newEffect)
    {
        // Проверяем: если такой эффект уже висит — просто обновляем время
        var existing = _activeEffects.Find(e => e.GetType() == newEffect.GetType());
        if (existing != null)
        {
            existing.OnRefresh(newEffect.Duration);
            return;
        }

        _activeEffects.Add(newEffect);
        newEffect.OnApply(_character);
    }

    private void Update()
    {
        for (int i = _activeEffects.Count - 1; i >= 0; i--)
        {
            var effect = _activeEffects[i];
            effect.OnUpdate(Time.deltaTime);

            if (effect.IsExpired)
            {
                effect.OnRemove();
                _activeEffects.RemoveAt(i);
            }
        }
    }

    public void RemoveAllEffects()
    {
        foreach (var effect in _activeEffects)
            effect.OnRemove();
        _activeEffects.Clear();
    }
}