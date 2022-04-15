using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStoreManager : MonoBehaviour
{   
    [SerializeField] private GameObject[] menus;

    [SerializeField] private GameObject[] arrows;
    [SerializeField] private Currency currency;
    

    
    public float fireArrowCost, lightningArrowCost, rainArrowCost, iceArrowCost, meteorArrowCost, healingArrowCost;
    [Header ("Cost Multiplier After Purchase")]
    public float upgradeMultiplier;
    
    private void Start()
    {
       
       foreach(GameObject arrow in arrows)
        {
            ArrowType arrowType = arrow.GetComponent<ArrowType>();

            switch (arrowType.typeOfArrow)
            {
                case ArrowType.TypeOfArrow.Fire:
                    
                    Debug.Log(arrow.GetComponent<ArrowType>().typeOfArrow + "ArrowDamage");
                    FireArrow fireArrow = arrow.GetComponent<FireArrow>();
                    PlayerPrefs.SetFloat(arrowType.ToString() + "ArrowDamage", arrowType.damage);
                    PlayerPrefs.SetFloat("ImpactDamage", arrowType.damage);
                    PlayerPrefs.SetFloat("DecayDamage", arrowType.damage * 0.016f);
                    PlayerPrefs.SetFloat("FireSize", fireArrow.fireSize);
                    Debug.Log("Damage: " + PlayerPrefs.GetFloat(arrowType + "ArrowDamage".ToString()));
                    Debug.Log("Impact Damage: " + PlayerPrefs.GetFloat("ImpactDamage"));
                    Debug.Log("Decay Damage: " + PlayerPrefs.GetFloat("DecayDamage"));
                    Debug.Log("Fire Size: " + PlayerPrefs.GetFloat("FireSize"));
                    break;
                case ArrowType.TypeOfArrow.Ice:
                    IceArrow iceArrow = arrow.GetComponent<IceArrow>();
                    PlayerPrefs.SetFloat(arrowType + "ArrowDamage", arrowType.damage);
                    PlayerPrefs.SetFloat("IceSizeX", iceArrow.IceSizeX);
                    PlayerPrefs.SetFloat("IceSizeY", iceArrow.IceSizeY);
                    PlayerPrefs.SetFloat("IceSizeZ", iceArrow.IceSizeZ);

                    break;
                case ArrowType.TypeOfArrow.MeteorShower:
                    MeteorShower meteorShower = arrow.GetComponent<MeteorShower>();
                    PlayerPrefs.SetFloat(arrowType + "ArrowDamage", arrowType.damage);
                    PlayerPrefs.SetFloat("MeteorTime", meteorShower.meteorTime);
                    break;
                case ArrowType.TypeOfArrow.Lightning:
                    PlayerPrefs.SetFloat(arrowType + "ArrowDamage", arrowType.damage);
                    LightningArrow lightningArrow = arrow.GetComponent<LightningArrow>();
                    PlayerPrefs.SetFloat("LightningSize", lightningArrow.lightningSize);
                    break;
                case ArrowType.TypeOfArrow.Heal:
                    HealArrow healArrow = arrow.GetComponent<HealArrow>();
                    PlayerPrefs.SetFloat("HealAmount", healArrow.healAmount);
                    break;
                case ArrowType.TypeOfArrow.Rain:
                    RainOfArrows rainOfArrows = arrow.GetComponent<RainOfArrows>();

                    PlayerPrefs.SetFloat(arrowType + "ArrowDamage", arrowType.damage);
                    PlayerPrefs.SetFloat("RainSpawnRate", rainOfArrows.spawnRate);
                    break;
                default: Debug.Log("Not an arrow");
                    break;
            }
        }

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
    public void SetFireArrowUpgrade()
    {
        if (currency.GetGold() >= fireArrowCost)
        {
            //Damage

            foreach (GameObject arrow in arrows)
            {
                ArrowType arrowType = arrow.GetComponent<ArrowType>();

                switch (arrowType.typeOfArrow)
                {
                    case ArrowType.TypeOfArrow.Fire:
                        float damage = PlayerPrefs.GetFloat(arrowType + "ArrowDamage");
                        Debug.Log(arrowType + "ArrowDamage");
                        Debug.Log("Damage 1: " + PlayerPrefs.GetFloat(arrowType + "ArrowDamage"));
                        damage += damage * 0.04f; //Change This To Change upgrade variable ratio
                        PlayerPrefs.SetFloat(arrowType + "ArrowDamage", damage);
                        Debug.Log("Damage 2: " + damage);
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
                        fireArrowCost += Mathf.Floor(fireArrowCost * upgradeMultiplier);
                        currency.SubtractGold(fireArrowCost);
                        break;

                    default:
                        Debug.Log("Not an arrow");
                        break;
                }
            }


        }
    }
    public void SetLightningArrowUpgrade()
    {
        if (currency.GetGold() >= lightningArrowCost)
        {
            foreach (GameObject arrow in arrows)
            {
                ArrowType arrowType = arrow.GetComponent<ArrowType>();

                switch (arrowType.typeOfArrow)
                {

                    case ArrowType.TypeOfArrow.Ice:
                        //Damage
                        float damage = PlayerPrefs.GetFloat(arrowType + "ArrowDamage");
                        damage += damage * 0.04f; //Change This To Change upgrade variable ratio
                        PlayerPrefs.SetFloat(arrowType + "ArrowDamage", damage);

                        //Size
                        float size = PlayerPrefs.GetFloat("LightningSize");
                        size += size * 0.27f; //Change This To Change upgrade variable ratio
                        PlayerPrefs.SetFloat("LightningSize", size);
                        lightningArrowCost += Mathf.Floor(lightningArrowCost * upgradeMultiplier);
                        //Change if it uses Diamonds/Gems
                        currency.SubtractGold(lightningArrowCost);
                        break;

                    default:
                        Debug.Log("Not an arrow");
                        break;
                }
            }


        }
    }

    public void SetRainArrowUpgrade()
    {
        if (currency.GetGold() >= rainArrowCost)
        {
            foreach (GameObject arrow in arrows)
            {
                ArrowType arrowType = arrow.GetComponent<ArrowType>();

                switch (arrowType.typeOfArrow)
                {
                  
                    case ArrowType.TypeOfArrow.Rain:
                        float damage = PlayerPrefs.GetFloat(arrowType + "ArrowDamage");
                        damage += damage * 0.04f;
                        PlayerPrefs.SetFloat(arrowType + "ArrowDamage", damage);
                        float spawnRate = PlayerPrefs.GetFloat("RainSpawnRate");
                        spawnRate += 1; //Change This To Change upgrade variable ratio
                        PlayerPrefs.SetFloat("RainSpawnRate", spawnRate);
                        rainArrowCost += Mathf.Floor(rainArrowCost * upgradeMultiplier);
                        //Change if it uses Diamonds/Gems
                        currency.SubtractGold(rainArrowCost);
                        break;
                    default:
                        Debug.Log("Not an arrow");
                        break;
                }
            }
            //Spawn Rate (Amount of Arrows)
            
        }
    }

    public void SetIceArrowUpgrade()
    {
        if (currency.GetGold() >= iceArrowCost)
        {
            //Damage
            foreach (GameObject arrow in arrows)
            {
                ArrowType arrowType = arrow.GetComponent<ArrowType>();

                switch (arrowType.typeOfArrow)
                {

                    case ArrowType.TypeOfArrow.Ice:
                        float damage = PlayerPrefs.GetFloat(arrowType + "ArrowDamage");
                        damage += damage * 0.04f; //Change This To Change upgrade variable ratio
                        PlayerPrefs.SetFloat(arrowType + "ArrowDamage", damage);

                        //Size
                        float size = PlayerPrefs.GetFloat("IceSizeX");
                        size += size * 0.27f; //Change This To Change upgrade variable ratio
                        PlayerPrefs.SetFloat("IceSizeX", size);
                        PlayerPrefs.SetFloat("IceSizeY", size);
                        PlayerPrefs.SetFloat("IceSizeZ", size);

                        //Change if it uses Diamonds/Gems
                        iceArrowCost += Mathf.Floor(iceArrowCost * upgradeMultiplier);

                        currency.SubtractGold(iceArrowCost);
                        break;
                    default:
                        Debug.Log("Not an arrow");
                        break;
                }
            }
          
            
            
        }
    }
    public void SetMeteorArrowUpgrade()
    {
        if (currency.GetGold() >= meteorArrowCost)
        {
            //Damage
            foreach (GameObject arrow in arrows)
            {
                ArrowType arrowType = arrow.GetComponent<ArrowType>();

                switch (arrowType.typeOfArrow)
                {

                    case ArrowType.TypeOfArrow.MeteorShower:
                        float damage = PlayerPrefs.GetFloat(arrowType + "ArrowDamage");
                        damage += damage * 0.04f; //Change This To Change upgrade variable ratio
                        PlayerPrefs.SetFloat(arrowType + "ArrowDamage", damage);

                        //Size
                        float meteorTime = PlayerPrefs.GetFloat("MeteorTime");
                        meteorTime += 1; //Change This To Change upgrade variable ratio

                        PlayerPrefs.SetFloat("MeteorTime", meteorTime);
                        meteorArrowCost += Mathf.Floor(meteorArrowCost * upgradeMultiplier);

                        //Change if it uses Diamonds/Gems

                        currency.SubtractGold(meteorArrowCost);
                        break;
                    default:
                        Debug.Log("Not an arrow");
                        break;
                }
            }
            
        }
    }

    public void SetHealingArrowUpgrade()
    {
        if (currency.GetGold() >= healingArrowCost)
        {
            //Heal
            foreach (GameObject arrow in arrows)
            {
                ArrowType arrowType = arrow.GetComponent<ArrowType>();

                switch (arrowType.typeOfArrow)
                {

                    case ArrowType.TypeOfArrow.Heal:
                        float healAmount = PlayerPrefs.GetFloat("HealAmount");
                        healAmount += 1; //Change This To Change upgrade variable ratio

                        PlayerPrefs.SetFloat("HealAmount", healAmount);
                        healingArrowCost += Mathf.Floor(healingArrowCost * upgradeMultiplier);

                        //Change if it uses Diamonds/Gems

                        currency.SubtractGold(healingArrowCost);
                        break;
                    default:
                        Debug.Log("Not an arrow");
                        break;
                }
            }
            
        }

    }
}
