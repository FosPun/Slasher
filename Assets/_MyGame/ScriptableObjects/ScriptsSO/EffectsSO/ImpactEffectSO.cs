using UnityEngine;

[CreateAssetMenu(fileName = "KnockbackEffect", menuName = "Scriptable Objects/Effects/Knockback")]
public class ImpactEffectSO : EffectSO
{
    [SerializeField] private float _horizontalForce = 8f;
    [SerializeField] private float _verticalLift = 1.5f;

    public override void Apply(GameObject instigator, GameObject target)
    {
        if (target.TryGetComponent<IImpactable>(out var knockbackable))
        {
            Vector3 direction = (target.transform.position - instigator.transform.position);
            direction.y = 0;
            direction.Normalize();

            Vector3 totalForce = (direction * _horizontalForce) + (Vector3.up * _verticalLift);
            knockbackable.ApplyImpact(totalForce);
        }
    }
}