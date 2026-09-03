
using UnityEngine;

[CreateAssetMenu(fileName = "CharacteristicsSO", menuName = "Scriptable Objects/CharacteristicsSO")]
public class CharacteristicsSO : ScriptableObject
{
    public float movementSpeed;
    public float dodgeDistance;
    public float dodgeDuration;
    public AnimationCurve dodgeCurve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(1, 0)); // Кривая по умолчанию
    public float attackSpeed;
    public int maxHealth;
    public int health;
    public float damage;
}
