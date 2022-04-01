using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStoreManager : MonoBehaviour
{
    public enum TypeOfArrow { Regular, Fire, Ice, MeteorShower, Lightning, Rain, Heal, Target };

    [HideInInspector]public TypeOfArrow typeOfArrow;

    public GameObject[] menus;
    private void Start()
    {
       

        /* Uncomment when scene switch is added 1 = true, 0 = false
        if (PlayerPrefs.GetInt("UnlockStore") == 1)
        {
            foreach (GameObject menu in menus)
            {
                menu.SetActive(true);
            }
        }
        else
        {
            foreach(GameObject menu in menus)
            {
                menu.SetActive(false);
            }
        }
        */
    }
    public void SetFireArrowUpgrade(float cost)
    {
        if (PlayerPrefs.GetFloat("Gold") >= cost)
        {
            //Damage
            typeOfArrow = TypeOfArrow.Fire;
            float damage = PlayerPrefs.GetFloat(typeOfArrow + "ArrowDamage");
            damage += damage * 0.04f; //Change This To Change upgrade variable ratio
            PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);

            PlayerPrefs.SetFloat("ImpactDamage", damage);
            PlayerPrefs.SetFloat("DecayDamage", damage * 0.016f);

            //Size
            float size = PlayerPrefs.GetFloat("FireSize");
            size += size * 0.27f; //Change This To Change upgrade variable ratio
            PlayerPrefs.SetFloat("FireSize", size);
            Debug.Log("Impact Damage: " + PlayerPrefs.GetFloat("ImpactDamage"));
            Debug.Log("Decay Damage: " + PlayerPrefs.GetFloat("DecayDamage"));
            Debug.Log("Fire Size: " + PlayerPrefs.GetFloat("FireSize"));
            //Change if it uses Diamonds/Gems
            float currentGold = PlayerPrefs.GetFloat("Gold");
            currentGold -= cost;
            PlayerPrefs.SetFloat("Gold", currentGold);
        }
    }
    public void SetLightningArrowUpgrade(float cost)
    {
        if (PlayerPrefs.GetFloat("Gold") >= cost)
        {
            //Damage
            typeOfArrow = TypeOfArrow.Lightning;
            float damage = PlayerPrefs.GetFloat(typeOfArrow + "ArrowDamage");
            damage += damage * 0.04f; //Change This To Change upgrade variable ratio
            PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);

            //Size
            float size = PlayerPrefs.GetFloat("LightningSize");
            size += size * 0.27f; //Change This To Change upgrade variable ratio
            PlayerPrefs.SetFloat("LightningSize", size);

            //Change if it uses Diamonds/Gems
            float currentGold = PlayerPrefs.GetFloat("Gold");
            currentGold -= cost;
            PlayerPrefs.SetFloat("Gold", currentGold);
        }
    }

    public void SetRainArrowUpgrade(float cost)
    {
        if (PlayerPrefs.GetFloat("Gold") >= cost)
        {
            //Spawn Rate (Amount of Arrows)
            typeOfArrow = TypeOfArrow.Rain;
            float spawnRate = PlayerPrefs.GetFloat("RainSpawnRate");
            spawnRate += 1; //Change This To Change upgrade variable ratio
            PlayerPrefs.SetFloat("RainSpawnRate", spawnRate);

            //Change if it uses Diamonds/Gems
            float currentGold = PlayerPrefs.GetFloat("Gold");
            currentGold -= cost;
            PlayerPrefs.SetFloat("Gold", currentGold);
        }
    }

    public void SetIceArrowUpgrade(float cost)
    {
        if (PlayerPrefs.GetFloat("Gold") >= cost)
        {
            //Damage
            typeOfArrow = TypeOfArrow.Ice;
            float damage = PlayerPrefs.GetFloat(typeOfArrow + "ArrowDamage");
            damage += damage * 0.04f; //Change This To Change upgrade variable ratio
            PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);

            //Size
            float size = PlayerPrefs.GetFloat("IceSizeX");
            size += size * 0.27f; //Change This To Change upgrade variable ratio
            PlayerPrefs.SetFloat("IceSizeX", size);
            PlayerPrefs.SetFloat("IceSizeY", size);
            PlayerPrefs.SetFloat("IceSizeZ", size);

            //Change if it uses Diamonds/Gems
            float currentGold = PlayerPrefs.GetFloat("Gold");
            currentGold -= cost;
            PlayerPrefs.SetFloat("Gold", currentGold);
        }
    }
    public void SetMeteorArrowUpgrade(float cost)
    {
        if (PlayerPrefs.GetFloat("Gold") >= cost)
        {
            //Damage
            typeOfArrow = TypeOfArrow.MeteorShower;
            float damage = PlayerPrefs.GetFloat(typeOfArrow + "ArrowDamage");
            damage += damage * 0.04f; //Change This To Change upgrade variable ratio
            PlayerPrefs.SetFloat(typeOfArrow + "ArrowDamage", damage);

            //Size
            float meteorTime = PlayerPrefs.GetFloat("MeteorTime");
            meteorTime += 1; //Change This To Change upgrade variable ratio

            PlayerPrefs.SetFloat("MeteorTime", meteorTime);

            //Change if it uses Diamonds/Gems
            float currentGold = PlayerPrefs.GetFloat("Gold");
            currentGold -= cost;
            PlayerPrefs.SetFloat("Gold", currentGold);
        }
    }

    public void SetHealingArrowUpgrade(float cost)
    {
        if (PlayerPrefs.GetFloat("Gold") >= cost)
        {
            //Heal
            typeOfArrow = TypeOfArrow.Heal;
            float healAmount = PlayerPrefs.GetFloat("HealAmount");
            healAmount += 1; //Change This To Change upgrade variable ratio

            PlayerPrefs.SetFloat("HealAmount", healAmount);

            //Change if it uses Diamonds/Gems
            float currentGold = PlayerPrefs.GetFloat("Gold");
            currentGold -= cost;
            PlayerPrefs.SetFloat("Gold", currentGold);
        }

    }
}
