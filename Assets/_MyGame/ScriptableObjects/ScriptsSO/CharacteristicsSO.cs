using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacteristicsSO", menuName = "Scriptable Objects/CharacteristicsSO")]
public class CharacteristicsSO : ScriptableObject
{
    public float movementSpeed;
    public float attackSpeed;
    public float health;
    public float damage;
}
