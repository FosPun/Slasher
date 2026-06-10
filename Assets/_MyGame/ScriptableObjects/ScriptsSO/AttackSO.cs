using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "AttackSO", menuName = "Scriptable Objects/AttackSO")]
public class AttackSO : ScriptableObject
{
    [Header("Animation")]
    public AnimationClip AnimationClip;
    public float TransitionDuration = 0.1f;

    [Header("Combat Stats")]
    public float Damage = 10f;
    
    [Header("Combo Tree")]
    public List<ComboTransition> ComboTransitions;
}
