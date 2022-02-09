using System.Collections;
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
    [SerializeField] GameObject[] Towers;
    

    int enemyIndex;
    int pointIndex;
    float t = 0;
    public float spawnRate = 5f;
    ////// Start is called before the first frame update
    void Start()
    {
        Towers = GameObject.FindGameObjectsWithTag("TowerArcher");
        Randomize();
        
        
    }

    ////// Update is called once per frame
    void Update()
    {
        
        // Spawn rate
        if (t > spawnRate)
        {
            Randomize();
        }
        t += Time.deltaTime;
    }
    //////Randomize a number from 0-Array Length
    public void Randomize()
    {
        enemyIndex = Random.Range(0, enemies.Length);
        pointIndex = Random.Range(0, spawnPoints.Length);
        

        Spawn();
    }
    /*
    void ChooseTower(GameObject enemy)
    {
        for (int i = 0; i < Towers.Length; i++)
        {
            switch (Towers[i].GetComponent<TowerArcher>().lane)
            {
                case TowerArcher.Lane.Lane1:
                    Towers[i].GetComponent<TowerArcher>().lane1.Add(enemy);
                    break;
                case TowerArcher.Lane.Lane2:
                    Towers[i].GetComponent<TowerArcher>().lane2.Add(enemy);
                    break;
                case TowerArcher.Lane.Lane3:
                    Towers[i].GetComponent<TowerArcher>().lane3.Add(enemy);
                    break;
            }
        }

    }
    */
    //////Spawn Enemies
    public void Spawn()
    {
        t = 0;
        string enemyName;
        GameObject enemy = Instantiate(enemies[enemyIndex], spawnPoints[pointIndex].position, Quaternion.identity);
        switch(pointIndex){
            case 0:
                enemy.GetComponent<Enemy>().lane = pointIndex + 1;
                enemy.GetComponent<EnemyAI>().checkpointPos = checkpointsLane1;
                enemy.GetComponent<EnemyAI>().checkpointIndex = Random.Range(0, checkpointsLane1.Length);
                
                //ChooseTower(enemy);
                for(int i = 0; i < Towers.Length; i++)
                {
                    if(Towers[i].GetComponent<TowerArcher>().lane == TowerArcher.Lane.Lane1)
                    {
                        Towers[i].GetComponent<TowerArcher>().lane1.Add(enemy);
                        //Debug.Log("Helloing");
                    }
                }
                break;
            case 1:
                enemy.GetComponent<Enemy>().lane = pointIndex + 1;
                enemy.GetComponent<EnemyAI>().checkpointPos = checkpointsLane2;
                enemy.GetComponent<EnemyAI>().checkpointIndex = Random.Range(0, checkpointsLane2.Length);
                //ChooseTower(enemy);
                for (int i = 0; i < Towers.Length; i++)
                {
                    if (Towers[i].GetComponent<TowerArcher>().lane == TowerArcher.Lane.Lane2)
                    {
                        Towers[i].GetComponent<TowerArcher>().lane2.Add(enemy);
                    }
                }

                break;
            case 2:
                enemy.GetComponent<Enemy>().lane = pointIndex + 1;
                enemy.GetComponent<EnemyAI>().checkpointPos = checkpointsLane3;
                enemy.GetComponent<EnemyAI>().checkpointIndex = Random.Range(0, checkpointsLane3.Length);
                //ChooseTower(enemy);
                for (int i = 0; i < Towers.Length; i++)
                {
                    if (Towers[i].GetComponent<TowerArcher>().lane == TowerArcher.Lane.Lane3)
                    {
                        Towers[i].GetComponent<TowerArcher>().lane3.Add(enemy);
                    }
                }
                break;
        }
        enemyName = enemy.GetComponent<Enemy>().enemyName +" (Lane: " + enemy.GetComponent<Enemy>().lane.ToString() + ")";
        enemy.name = enemyName;
        //////set destination position
        enemy.GetComponent<EnemyAI>().towerPos = towerPos[pointIndex];
        //foreach(GameObject tower in Towers)
        //{
        //    tower.GetComponent<TowerArcher>().EnemySpawned(enemy);
        //}
        enemy.GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.Checkpoints;


    }


}
