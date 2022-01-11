﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOfArrows : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    public int spawnAmount;
    public float yPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rain()
    {
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + yPos, this.transform.position.z);
        for(int i = 0; i < spawnAmount; i++)
        {
            GameObject arrowInstance = Instantiate(arrow);
            arrowInstance.transform.position = pos;
            arrowInstance.GetComponent<Rigidbody>().AddForce(-transform.up * 1500, ForceMode.Impulse);
            arrowInstance.GetComponent<Arrow>().launched = true;

        }
    }
   
}