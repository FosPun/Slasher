using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSO", menuName = "Scriptable Objects/AttackSO")]
public class AttackSO : ScriptableObject
{
    [Header("Animation")]
    public string AnimatorStateName;

    [Header("Combat Stats")]
    public float Damage = 10f;
    
    [Header("Combo Tree")]
    public List<ComboTransition> ComboTransitions;
}
