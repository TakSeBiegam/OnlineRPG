using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyController : NetworkBehaviour
{
    [SerializeField]
    public EnemyBasicStats enemyBasicStats;

    [SerializeField]
    [SyncVar] float currentHealth;

    void Awake()
    {
        currentHealth = (enemyBasicStats.maxHealth + 1);
    }

    private bool checkIsDead()
    {
        //CHECK IN NETWORK BEHAVOR IS THERE NO ASYNCHRONIZATION PROBLEM !!!!
        //IF first player killed monster and after 200ms second player killed monster, then second player will be able to kill monster again and they do 2 kill from 1 monster
        return (currentHealth - 1 <= 0);
    }

    void Update()
    {
        if (checkIsDead())
        {
            CmdDestroyGameObject(gameObject);
        }
    }

    public float getCurrentHealth()
    {
        //Return currentHealth with minus 1 because we need to confuse ppl with CheatEngine
        return currentHealth - 1;
    }

    public void getDamage(float damage)
    {
        currentHealth -= damage;
    }

    [Server]
    void CmdDestroyGameObject(GameObject other)
    {

        NetworkServer.Destroy(gameObject);
    }
}
