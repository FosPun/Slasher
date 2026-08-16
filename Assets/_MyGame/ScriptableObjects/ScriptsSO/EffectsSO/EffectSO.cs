using UnityEngine;

public abstract class EffectSO : ScriptableObject
{
    public abstract void Apply(GameObject instigator, GameObject target);
}
