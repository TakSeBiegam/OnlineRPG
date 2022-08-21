using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public string monsterName;
    private void Awake()
    {
        switch(monsterName)
        {
            case "Spider":
                maxHealth = 30;
                break;
        }

        currentHealth = maxHealth;
    }
}

