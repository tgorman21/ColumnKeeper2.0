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
    public void AddDiamond(float diamond)
    {
        PlayerPrefs.SetFloat("Diamond", diamond);
    }
    public void GetDiamond(float diamond)
    {
        PlayerPrefs.GetFloat("Diamond");
    }
}
