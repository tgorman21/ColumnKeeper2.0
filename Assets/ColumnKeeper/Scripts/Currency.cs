using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    
   
    public void AddGold(float gold)
    {
        PlayerPrefs.SetFloat("Gold", gold);
    }
    public void GetGold()
    {
        PlayerPrefs.GetFloat("Gold");
    }
    public void AddDiamond(float gems)
    {
        PlayerPrefs.SetFloat("Gems", gems);
    }
    public void GetDiamond(float gems)
    {
        PlayerPrefs.GetFloat("Gems");
    }
}
