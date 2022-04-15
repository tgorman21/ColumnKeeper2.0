using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI diamondText;
    [SerializeField] private TextMeshProUGUI fireArrow, iceArrow, meteorArrow, lightningArrow, healArrow;
    [SerializeField] private ArrowStoreManager arrowStore;

    [Header("Dev Tools (Don't Need For Script to Work)")]
    [SerializeField] private bool addGold;
    [SerializeField] private bool addDiamond;
    [SerializeField] private bool resetCurrency;
    [SerializeField] private bool upgradeFire;

    private Currency currency;

    private void Start() => currency = GetComponent<Currency>();

    private void Update()
    {
        fireArrow.SetText(arrowStore.fireArrowCost.ToString("##.##"));
        //iceArrow.SetText(arrowStore.iceArrowCost.ToString("##.##"));
        //meteorArrow.SetText(arrowStore.meteorArrowCost.ToString("##.##"));
        //lightningArrow.SetText(arrowStore.lightningArrowCost.ToString("##.##"));
        //healArrow.SetText(arrowStore.healingArrowCost.ToString("##.##"));
        
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
            goldText.SetText("0");
        }
        else
        {
            goldText.SetText(currency.GetGold().ToString("##"));
        }

        if (currency.GetDiamond() == 0)
        {
            diamondText.SetText("0");
        }
        else
        {
            diamondText.SetText(currency.GetDiamond().ToString("##"));
        }
    }
}
