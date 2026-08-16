using UnityEngine;

[CreateAssetMenu(fileName = "KnockupEffectSO", menuName = "Scriptable Objects/Effects/KnockupEffect")]
public class KnockupEffectSO : EffectSO
{
    [SerializeField] float force;
    
    public override void Apply(GameObject instigator, GameObject target)
    {
        if (target.TryGetComponent<IKnockupable>(out var knockupable))
        {
            knockupable.ApplyKnockup(force);
        }
    }
}
