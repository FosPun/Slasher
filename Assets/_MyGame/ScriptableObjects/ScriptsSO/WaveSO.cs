using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "WaveSO", menuName = "Scriptable Objects/WaveSO")]
public class WaveSO : ScriptableObject
{
    public EnemySO[] EnemiesDataToSpawn;
    public int AmountOfEnemiesToSpawn;
}
