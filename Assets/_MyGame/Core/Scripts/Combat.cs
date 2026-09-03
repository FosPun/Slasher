using System;
using UnityEngine;
using Zenject;

public class Combat : MonoBehaviour
{
    public event Action OnAttackStarted;
    public event Action OnAttackFinished;

    [SerializeField] private LayerMask _layerMaskToHit;

    private Animator _animator;
    private CombatAnimator _combatAnimator;
    private readonly Collider[] _hitColliders = new Collider[20];

    public bool IsAttacking { get; private set; }
    public AttackSO CurrentActiveAttack { get; private set; }

    [Inject]
    public void Construct(Animator animator, CombatAnimator combatAnimator)
    {
        _animator = animator;
        _combatAnimator = combatAnimator;
    }

    private void OnEnable()
    {
        _combatAnimator.OnAttackAnimationFinished += HandleAttackFinished;
        _combatAnimator.OnAttack += AttackCast;
    }

    private void OnDisable()
    {
        _combatAnimator.OnAttackAnimationFinished -= HandleAttackFinished;
        _combatAnimator.OnAttack -= AttackCast;
    }

    public void ExecuteAttack(AttackSO attackSo)
    {
        if (attackSo == null) return;

        CurrentActiveAttack = attackSo;
        IsAttacking = true;
        OnAttackStarted?.Invoke();

        _animator.CrossFade(attackSo.animationLabel, 0.1f);
    }

    private void HandleAttackFinished()
    {
        IsAttacking = false;
        CurrentActiveAttack = null;
        OnAttackFinished?.Invoke();
    }

    private void AttackCast()
    {
        if (CurrentActiveAttack == null) return;

        
        Vector3 castPosition = transform.position + transform.forward * CurrentActiveAttack.positionOffset;
        var hits = Physics.OverlapSphereNonAlloc( castPosition, CurrentActiveAttack.radius, _hitColliders,
            _layerMaskToHit);

        for (var i = 0; i < hits; i++)
        {
            if (_hitColliders[i].TryGetComponent(out Health health)) health.TakeDamage(CurrentActiveAttack.damage);

            if (CurrentActiveAttack.effects != null)
                foreach (var effectSo in CurrentActiveAttack.effects)
                    effectSo?.Apply(gameObject, _hitColliders[i].gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if (CurrentActiveAttack == null) return;
        
        Gizmos.color = Color.red;
        Vector3 castPosition = transform.position + transform.forward * CurrentActiveAttack.positionOffset;
        Gizmos.DrawSphere(castPosition, CurrentActiveAttack.radius);

    }
}