﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.SeekTower;
        }
    }
}
