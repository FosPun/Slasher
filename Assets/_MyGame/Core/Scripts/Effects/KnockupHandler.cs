using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class KnockupHandler : BaseEffectHandler, IKnockupable
{
    public void ApplyKnockup(float force)
    {
        StartCoroutine(KnockupCoroutine(force));
    }

    private IEnumerator KnockupCoroutine(float force)
    {
        DisableAgent();
        
        _rigidbody.AddForce(force * Vector3.up, ForceMode.Impulse);

        yield return new WaitForSeconds(0.1f);

        while (!_groundChecker.IsGrounded)
        {
            yield return null;
        }


        EnableAgent();
    }
    
}
