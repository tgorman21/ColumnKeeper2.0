﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] private float health;
    private float baseHealth;
    // Start is called before the first frame update
    void Start()
    {
        baseHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            //GameOver
        }
    }

    //Deals Damage to Tower
    public void DealDamage(float damage)
    {
        health -= damage;
    }

    //Upgrades Tower
    public void UpgradeHealth(float health)
    {
        this.health = health;
    }

    //Heals Tower
    public void HealTower(float healAmount)
    {
        //Total health after dealing health 
        float totalHealth = health + healAmount;

        //Checks if health is less than total health
        if(totalHealth <= baseHealth)
        {
            //Heals tower
            health = totalHealth;
        }
        //Caps health at base health
        else if(totalHealth > baseHealth)
        {
            health = baseHealth;
        }
    }
}
