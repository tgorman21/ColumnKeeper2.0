using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStoreManager : MonoBehaviour
{
    public enum TypeOfArrow { Regular, Fire, Ice, MeteorShower, Lightning, Rain, Heal, Target };

    [HideInInspector]public TypeOfArrow typeOfArrow;
   
   
    public void SetFireArrowUpgrade()
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
    }
    public void SetLightningArrowUpgrade()
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
    }

    public void SetRainArrowUpgrade()
    {
        //Spawn Rate (Amount of Arrows)
        typeOfArrow = TypeOfArrow.Rain;
        float spawnRate = PlayerPrefs.GetFloat("RainSpawnRate");
        spawnRate += 1; //Change This To Change upgrade variable ratio
        PlayerPrefs.SetFloat("RainSpawnRate", spawnRate);
    }

    public void SetIceArrowUpgrade()
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
    }
    public void SetMeteorArrowUpgrade()
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
    }

    public void SetHealingArrowUpgrade()
    {
        //Heal
        typeOfArrow = TypeOfArrow.Heal;
        float healAmount = PlayerPrefs.GetFloat("HealAmount");
        healAmount += 1; //Change This To Change upgrade variable ratio

        PlayerPrefs.SetFloat("HealAmount", healAmount);
    }

   
}
