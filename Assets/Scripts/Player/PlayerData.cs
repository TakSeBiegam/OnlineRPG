using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CharacterClass
{
    Warrior,
    Mage,
    Rogue,
    Priest,
    Beggar,
    None
}

public class PlayerData : MonoBehaviour
{
    private CharacterClass characterClass;
    public float attackCooldown = 2f;
    public float attackRange = 5f;
    public float attackDamage = 10f;
    public float movementSpeed = 10f;
    public Dictionary<int, Quest> activeQuests = new Dictionary<int, Quest>();

    // public void AddKilledMonster(string monsterName)
    // {
    //     foreach (Quest q in activeQuests)
    //     {
    //         if (q.monsterToKill.ContainsKey(monsterName) && !q.isDone)
    //         {
    //             q.monsterKilled[monsterName]++;
    //             if (q.monsterKilled[monsterName] >= q.monsterToKill[monsterName])
    //             {
    //                 q.isDone = true;
    //             }
    //         }
    //     }
    // }

    public void AddQuestForPlayer(int questNumber)
    {
        activeQuests.Add(questNumber, new Quest());
    }
}

