using UnityEngine;

[CreateAssetMenu(fileName = "KnockbackEffect", menuName = "Scriptable Objects/Effects/Knockback")]
public class KnockbackEffectSO : EffectSO
{
    [SerializeField] private float _force = 8f;
    [SerializeField] private float _duration = 0.2f;

    public override void Apply(GameObject instigator, GameObject target)
    {
        if (target.TryGetComponent<IKnockbackable>(out var knockbackable))
        {
            knockbackable.ApplyKnockback(_force, _duration, instigator.transform.position);
        }
    }
}