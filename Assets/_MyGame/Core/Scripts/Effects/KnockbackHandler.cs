using System.Collections;
using UnityEngine;

public class KnockbackHandler : BaseEffectHandler, IKnockbackable
{
    public void ApplyKnockback(float force, float duration, Vector3 attackerPosition)
    {
        StopAllCoroutines();
        StartCoroutine(KnockbackCoroutine(force, duration, attackerPosition));
    }

    private IEnumerator KnockbackCoroutine(float force, float duration, Vector3 attackerPosition)
    {
        DisableAgent();

        Vector3 direction = new Vector3(attackerPosition.x, transform.position.y, attackerPosition.z);
        transform.LookAt(direction);
        _rigidbody.AddForce(-transform.forward * force, ForceMode.Impulse);
        
        yield return new WaitForSeconds(duration);
        
        while (!_groundChecker.IsGrounded)
        {
            yield return null;
        }

        EnableAgent();
    }
}