﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypnoArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hypnotize(EnemyAI enemyAI)
    {
        enemyAI.currentState = EnemyAI.BehaviorState.Hypno;
    }
}