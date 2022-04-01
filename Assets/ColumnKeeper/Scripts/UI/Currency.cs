using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public void AddGold(float gold)
    {
        float currentGold = PlayerPrefs.GetFloat("Gold");
        currentGold += gold;
        PlayerPrefs.SetFloat("Gold", currentGold);
    }
    public void SubtractGold(float gold)
    {
        float currentGold = PlayerPrefs.GetFloat("Gold");
        currentGold -= gold;
        PlayerPrefs.SetFloat("Gold", currentGold);
    }

    public float GetGold()
    {
        return PlayerPrefs.GetFloat("Gold");
    }
    public void AddDiamond(float gems)
    {
        float currentGems = PlayerPrefs.GetFloat("Gems");
        currentGems += gems;
        PlayerPrefs.SetFloat("Gems", currentGems);
    }
    public void SubtractDiamond(float gems)
    {
        float currentGems = PlayerPrefs.GetFloat("Gems");
        currentGems -= gems;
        PlayerPrefs.SetFloat("Gems", currentGems);
    }
    public float GetDiamond()
    {
        return PlayerPrefs.GetFloat("Gems");
    }
    public void ResetCurrency()
    {
        PlayerPrefs.SetFloat("Gold", 0);
        PlayerPrefs.SetFloat("Gems", 0);
    }
}