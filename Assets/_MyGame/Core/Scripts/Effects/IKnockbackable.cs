using UnityEngine;

public interface IKnockbackable
{
    void ApplyKnockback(float force, float duration, Vector3 attackerPosition);
}