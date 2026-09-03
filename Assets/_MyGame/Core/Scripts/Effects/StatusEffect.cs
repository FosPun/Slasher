using UnityEngine;

public abstract class StatusEffect
{
    public float Duration { get; protected set; }
    public float TimeRemaining { get; set; }
    public bool IsExpired => TimeRemaining <= 0;

    protected Character Target;
    protected GameObject Instigator;

    public StatusEffect(float duration, GameObject instigator)
    {
        Duration = duration;
        TimeRemaining = duration;
        Instigator = instigator;
    }

    public virtual void OnApply(Character target)
    {
        Target = target;
    }

    public virtual void OnUpdate(float deltaTime)
    {
        TimeRemaining -= deltaTime;
    }

    public virtual void OnRemove() { }

    public virtual void OnRefresh(float additionalDuration)
    {
        TimeRemaining = Mathf.Max(TimeRemaining, additionalDuration);
    }
}