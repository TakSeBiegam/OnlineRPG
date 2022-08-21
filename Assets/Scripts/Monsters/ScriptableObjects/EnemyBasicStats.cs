using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBasicStats-Object", menuName = "ScriptableObjects/EnemyStats")]
public class EnemyBasicStats : ScriptableObject
{
    [field: SerializeField]
    public int maxHealth { get; private set; }
    [field: SerializeField]
    public float movementSpeed { get; private set; }
    [field: SerializeField]
    public string monsterName { get; private set; }

    public EnemyBasicAttack basicAttack;

}
