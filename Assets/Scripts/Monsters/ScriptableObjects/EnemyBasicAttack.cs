using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBasicStats-Object", menuName = "ScriptableObjects/EnemyBasicAttack")]
public class EnemyBasicAttack : ScriptableObject
{
    public int attackRange { get; private set; } = 1;
    public int attackDamage { get; private set; } = 10;
}
