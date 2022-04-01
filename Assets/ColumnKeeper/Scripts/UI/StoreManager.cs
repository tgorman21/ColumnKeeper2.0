using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    Currency currency;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI diamondText;
    [Header("Dev Tools (Don't Need For Script to Work")]
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
            arrowStore.SetFireArrowUpgrade(2);
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
