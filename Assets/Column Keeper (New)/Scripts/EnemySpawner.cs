﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform[] towerPos;
    [SerializeField] Transform[] checkpointsLane1;
    [SerializeField] Transform[] checkpointsLane2;
    [SerializeField] Transform[] checkpointsLane3;
    int enemyIndex;
    int pointIndex;
    float t = 0;
    public float spawnRate = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Randomize();
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn rate
        if (t > spawnRate)
        {
            Randomize();
        }
        t += Time.deltaTime;
    }
    //Randomize a number from 0-Array Length
    public void Randomize()
    {
        enemyIndex = Random.Range(0, enemies.Length);
        pointIndex = Random.Range(0, spawnPoints.Length);
        

        Spawn();
    }
    //Spawn Enemies
    public void Spawn()
    {
        t = 0;
        GameObject enemy = Instantiate(enemies[enemyIndex], spawnPoints[pointIndex].position, Quaternion.identity);
        switch(pointIndex){
            case 0:
                enemy.GetComponent<Enemy>().lane = pointIndex + 1;
                enemy.GetComponent<EnemyAI>().checkpointPos = checkpointsLane1;
                enemy.GetComponent<EnemyAI>().checkpointIndex = Random.Range(0, checkpointsLane1.Length);
                break;
            case 1:
                enemy.GetComponent<Enemy>().lane = pointIndex + 1;
                enemy.GetComponent<EnemyAI>().checkpointPos = checkpointsLane2;
                enemy.GetComponent<EnemyAI>().checkpointIndex = Random.Range(0, checkpointsLane2.Length);
                break;
            case 2:
                enemy.GetComponent<Enemy>().lane = pointIndex + 1;
                enemy.GetComponent<EnemyAI>().checkpointPos = checkpointsLane3;
                enemy.GetComponent<EnemyAI>().checkpointIndex = Random.Range(0, checkpointsLane3.Length);
                break;
        }

        //set destination position
        enemy.GetComponent<EnemyAI>().towerPos = towerPos[pointIndex];

        enemy.GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.Checkpoints;


    }


}
