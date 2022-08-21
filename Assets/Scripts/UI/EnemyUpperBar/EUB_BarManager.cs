using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EUB_BarManager : MonoBehaviour
{
    public GameObject monster;
    public TextMeshProUGUI monsterName;
    private float monsterMaxHealth;
    public Image healthBar;

    void Update()
    {
        if (monster == null || !monster.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            healthBar.fillAmount = monster.GetComponent<EnemyController>().getCurrentHealth() / monsterMaxHealth;
        }

    }
    void OnEnable()
    {
        monsterMaxHealth = monster.gameObject.GetComponent<EnemyController>().enemyBasicStats.maxHealth;
        monsterName.text = monster.gameObject.GetComponent<EnemyController>().enemyBasicStats.monsterName;
    }
}
