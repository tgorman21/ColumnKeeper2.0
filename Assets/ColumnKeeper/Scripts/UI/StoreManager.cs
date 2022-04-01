using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    Currency currency;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI diamondText;
    [SerializeField] TextMeshProUGUI fireArrow, iceArrow, meteorArrow, lightningArrow, healArrow;
    [Header("Dev Tools (Don't Need For Script to Work)")]
    [SerializeField] bool addGold;
    [SerializeField] bool addDiamond;
    [SerializeField] bool resetCurrency;
    [SerializeField] bool upgradeFire;
    [SerializeField] ArrowStoreManager arrowStore;
    // Start is called before the first frame update
    void Start()
    {
        currency = GetComponent<Currency>();
        
    }

    // Update is called once per frame
    void Update()
    {
        fireArrow.SetText(arrowStore.fireArrowCost.ToString("Upgrade Cost: ##.##"));
        iceArrow.SetText(arrowStore.iceArrowCost.ToString("Upgrade Cost: ##.##"));
        meteorArrow.SetText(arrowStore.meteorArrowCost.ToString("Upgrade Cost: ##.##"));
        lightningArrow.SetText(arrowStore.lightningArrowCost.ToString("Upgrade Cost: ##.##"));
        healArrow.SetText(arrowStore.healingArrowCost.ToString("Upgrade Cost: ##.##"));
        //Test
        if (addGold)
        {
            addGold = false;
            currency.AddGold(1);
        }
        if (addDiamond)
        {
            addDiamond = false;
            currency.AddDiamond(1);
        }
        if (resetCurrency)
        {
            resetCurrency = false;
            currency.ResetCurrency();
        }

        if (upgradeFire)
        {
            upgradeFire = false;
            arrowStore.SetFireArrowUpgrade();
        }

        //Actual Script
        if (currency.GetGold() == 0)
        {
            goldText.SetText("Gold: 0");
        }
        else
        {
            goldText.SetText(currency.GetGold().ToString("Gold: ##"));
        }
        if (currency.GetDiamond() == 0)
        {
            diamondText.SetText("Diamond: 0");
        }
        else
        {
            diamondText.SetText(currency.GetDiamond().ToString("Diamond: ##"));
        }
    }
}
