using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    
   
    public void AddGold(float gold)
    {
        PlayerPrefs.SetFloat("Gold", gold);
    }

    public void AddDiamond(float diamond)
    {
        PlayerPrefs.SetFloat("Diamond", diamond);
    }
}
