using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHp : MonoBehaviour
{
    private RectTransform towerHP;
    private TowerHealth towerHealth;
    private float baseHealth;

    void Start()
    {
        towerHP = GetComponent<RectTransform>();
        towerHealth = GameObject.FindGameObjectWithTag("Tower").GetComponent<TowerHealth>();
        baseHealth = towerHealth.health;
    }

    void Update()
    {
        if (towerHealth.health >= 0)
        {
            if (towerHP != null)
                towerHP.localScale = new Vector3(towerHealth.health / baseHealth, 1, 1);
        }
        if (towerHealth.health < 0)
        {
            towerHP.localScale = new Vector3(0, 1, 1);
        }
    }
}
