using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SimpleAttack : NetworkBehaviour
{
    public float lastAttackTime = 0f;
    public GameObject target;

    void Awake()
    {
        setTargetToNull();
        lastAttackTime = 0f;
    }

    void Update()
    {
        lastAttackTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.BackQuote) && target != null && isLocalPlayer)
        {
            doAttack();
        }
    }

    public void doAttack()
    {
        if (
            lastAttackTime > gameObject.GetComponent<PlayerData>().attackCooldown &&
            Vector3.Distance(transform.position, target.transform.position) < gameObject.GetComponent<PlayerData>().attackRange &&
            target.name != "NPC"
            )
        {
            CmdDamageToMonster(target, gameObject.GetComponent<PlayerData>().attackDamage);
            lastAttackTime = 0f;
        }
        return;
    }

    public void setTargetToNull()
    {
        target = null;
    }

    [Command]
    void CmdDamageToMonster(GameObject target, float damage)
    {
        target.GetComponent<EnemyController>().getDamage(damage);
    }

}
