using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealArrow : MonoBehaviour
{
    [SerializeField] public float healAmount;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("HealAmount", healAmount);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Calls heal function for tower
    public void HealTower(GameObject tower)
    {
        tower.GetComponent<TowerHealth>().HealTower(PlayerPrefs.GetFloat("HealAmount"));
    }
}
