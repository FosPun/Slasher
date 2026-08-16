using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AttackSO", menuName = "Scriptable Objects/AttackSO")]
public class AttackSO : ScriptableObject
{
    public AttackInput attackInput;
    public string animationLabel;
    public int cost;
    [Header("Combat Stats")] 
    public int damage = 10;
    public float positionOffset;
    public float radius = 1f;

    public List<EffectSO> effects;
    [Header("Transitions")]
    public List<AttackSO> transitions;
}
