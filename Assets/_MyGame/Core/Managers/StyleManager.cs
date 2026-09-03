using System.Collections;
using UnityEngine;
using Zenject;

public class StyleManager : MonoBehaviour
{
    [SerializeField] private float timeTomeResetCombo = 3f;
    [SerializeField] private int stylePerHit = 5;
    private int StyleMeter = 0;
    private Coroutine StyleCoroutine;
    private Combat _combat;
    private AttackSO _previousAttack;
    

    [Inject]
    private void Construct(PlayerCombo playerCombo)
    {
        _combat = playerCombo.Combat;
    }

    private void OnEnable()
    {
        EventBus.Subscribe<EnemyHitEvent>(CalculateStyle);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<EnemyHitEvent>(CalculateStyle);
    }

    private void CalculateStyle(EnemyHitEvent obj)
    {
        if (StyleCoroutine == null)
        {
            StyleCoroutine = StartCoroutine(StartStyleCoroutine());
        }
        else
        {
            StopCoroutine(StyleCoroutine);
            StartCoroutine(StartStyleCoroutine());
        }
        
    }

    private  IEnumerator StartStyleCoroutine()
    {
        if (_previousAttack != _combat.CurrentActiveAttack)
        {
            StyleMeter =+ stylePerHit;
            _previousAttack = _combat.CurrentActiveAttack;
        }
        else
        {
            StyleMeter++;
        }
        yield return new WaitForSeconds(timeTomeResetCombo);
        StyleMeter = 0;
        StyleCoroutine = null;
        _previousAttack = null;
    }
}
