using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public float health = 200;
    private float baseHealth;
   
    bool switchingScene;
   
    void Start()
    {
        
        
        switchingScene = true;
        baseHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

        if(health <= 0)
        {
            //GameOver
            if(switchingScene)
            {
                switchingScene = false;
                CustomSceneManager.instance.GoToScene("MainMenu");
            }
        }
       
    }

    //Deals Damage to Tower
    public void DealDamage(float damage)
    {
        health -= damage;
        

    }

    //Upgrades Tower
    public void UpgradeHealth()
    {
        
        this.health = PlayerPrefs.GetFloat("TowerHealth");
        
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
