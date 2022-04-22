﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Place Holder For Portal Beam")]
    [Tooltip ("Don't Know if it's a Particle System Just a place holder for now")]
    [SerializeField] ParticleSystem[] portalBeams;

    [Header ("Enemy and Spawner Transforms")]
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform[] lookAtObj;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform[] towerPos;
    [SerializeField] Transform[] checkpointsLane1;
    [SerializeField] Transform[] checkpointsLane2;
    [SerializeField] Transform[] checkpointsLane3;
    [SerializeField] GameObject[] Towers;
    [SerializeField] bool waves; //Determines if true it will use Wave system and if false it will use endless mode
    public bool archersShoot;
    [HideInInspector]public List<GameObject> enemyCheck = new List<GameObject>(); //List to manage if enemies are destroyed
    int enemyIndex; //Enemy index in enmies array
    int pointIndex; //Point of wave lane
    float t = 0; //Timer to spawn enemies
    float enemiesSpawned;
    public float spawnRate = 5f; //Rate of spawn
    public float amountOfEnemiesSpawned; //Amount of enemies to spawn in a wave before it switches
    private float twentyPercent;
    private float fortyPercent;
    private float sixtyPercent;
    private float eightyPercent;
    [SerializeField] private CharacterDialog characterDialog;
    [HideInInspector] public enum EnemyName { Goblin, Orc, Troll, Skeleton, Mushroom, Lich, Witch, Vampire, Derzin, Ingrar, Zarzog, Xenoria }; //Names of enemies and bosses
    [HideInInspector] public EnemyName enemyName;

    void Start()
    {
        //twentyPercent = Mathf.Floor(amountOfEnemiesSpawned * 0.2f);
        //fortyPercent = Mathf.Floor(amountOfEnemiesSpawned * 0.4f);
        //sixtyPercent = Mathf.Floor(amountOfEnemiesSpawned * 0.6f);
        //eightyPercent = Mathf.Floor(amountOfEnemiesSpawned * 0.4f);
        

        //Checks if there are towers
        if (GameObject.FindGameObjectsWithTag("TowerArcher") != null)
        {
            //If there are towers set it to the gameobject Towers
            Towers = GameObject.FindGameObjectsWithTag("TowerArcher");
        }
        enemiesSpawned = 0;
        float currentDestroyed = 0;
        switch (enemyName)
        {

            case EnemyName.Goblin:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);

                break;
            case EnemyName.Orc:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);

                break;
            case EnemyName.Troll:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Skeleton:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Mushroom:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Lich:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Witch:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Vampire:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);

                break;
            case EnemyName.Derzin:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Ingrar:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Zarzog:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;
            case EnemyName.Xenoria:
                PlayerPrefs.SetFloat(enemyName + "WantedPoster", currentDestroyed);
                PlayerPrefs.SetFloat(enemyName + "Spawned", 0);
                PlayerPrefs.SetFloat(enemyName + "TotalSpawned", 0);
                break;

            default:
                Debug.Log("Not an enemy");
                break;
        }
        

        switch (waves)
        {
            case true:
                enemyIndex = 0;
                pointIndex = 0;
                Randomize("Both");
                break;
            case false:
                // Spawn rate
                Randomize("Both");
                break;
        }


    }

    void Update()
    {
        PlayVoiceLines();
        switch (waves)
        {
            case true:
                WaveSystem();
                break;
            case false:
                // Spawn rate
                Endless();
                break;
        }
        
    }

    private void PlayVoiceLines()
    {
        switch (enemiesSpawned)
        {
            case var value when value == twentyPercent:
                characterDialog.PlayAudio();
                break;
            case var value when value == fortyPercent:
                characterDialog.PlayAudio();
                break;
            case var value when value == sixtyPercent:
                characterDialog.PlayAudio();
                break;
            case var value when value == eightyPercent:
                characterDialog.PlayAudio();
                break;
            default: return;
        }
    }
    //Function for endless mode
    public void Endless()
    {
        if (t > spawnRate)
        {
            Randomize("Both");
        }
        t += Time.deltaTime;
    }
    public bool AllEnemiesSpawned()
    {
        if (enemiesSpawned == amountOfEnemiesSpawned)
            return true;
        else
            return false;
    }
    //Funtion for Wave move
    public void WaveSystem()
    {
        //Debug.Log("Enemies Spawned "+enemiesSpawned);
        //Debug.Log("Enemies Count " + enemyCheck.Count);
        //Debug.Log("Enemy Index " + enemyIndex);

        if (enemiesSpawned < amountOfEnemiesSpawned)
        {

            

            switch (enemies.Length > 0)
            {
                case false:

                    if (t > spawnRate)
                    {
                        Randomize("Both");
                    }
                    t += Time.deltaTime;

                    break;
                case true:
                    if (t > spawnRate)
                    {
                        if (enemyCheck.Count > 0)
                        {
                            Randomize("Both");
                        }
                    }

                    t += Time.deltaTime;
                    break;

            }
        }
        /*
        //Spawner Chooses next enemy (If all enemies are destroyed before Set amount to spawn it will spawn next wave)
         if(enemyCheck.Count == 0)
        {
            
            enemiesSpawned = 0;
            t = 0;
            ChooseNextEnemy();
        }
        */

}
    //Checks to Spawn next enemy
    public void ChooseNextEnemy()
    {
        enemyIndex++;
        if (enemyIndex < enemies.Length)
        {
            
            Randomize("Both");
        }
        else if (enemyIndex > enemies.Length)
        {
            enemyIndex = 0;
            Randomize("Both");
        }
    }
    //////Randomize a number from 0-Array Length
    public void Randomize(string whatToRandomize)
    {
        switch(whatToRandomize)
        {
            case "EnemyIndex":
                enemyIndex = Random.Range(0, enemies.Length);
                break;
            case "PointIndex":
                pointIndex = Random.Range(0, spawnPoints.Length);
                break;
            case "Both":
                enemyIndex = Random.Range(0, enemies.Length);
                pointIndex = Random.Range(0, spawnPoints.Length);
                break;
            default:
                Debug.Log("Not an Option");
                break;

        }
       
        

        Spawn(enemyIndex, pointIndex);
    }
   
    //////Spawn Enemies
    public void Spawn(int enemyIndex, int pointIndex)
    {
        t = 0;
        enemiesSpawned++;
        string enemyName;
        
        GameObject enemy = Instantiate(enemies[enemyIndex], spawnPoints[pointIndex].position, Quaternion.identity);
        //////set destination position
        enemy.GetComponent<EnemyAI>().towerPos = towerPos[pointIndex];
        if (lookAtObj != null)
        {
            enemy.transform.LookAt(lookAtObj[pointIndex]);
        }
        enemyCheck.Add(enemy);
        switch(pointIndex){
            case 0:
                if (portalBeams != null)
                {
                    portalBeams[pointIndex].Play();
                }
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
                if (portalBeams != null)
                {
                    portalBeams[pointIndex].Play();
                }
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
                if(portalBeams != null)
                {
                    portalBeams[pointIndex].Play();
                }
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
        float spawned = PlayerPrefs.GetFloat(enemy.GetComponent<Enemy>().enemyName + "Spawned");
        spawned++;
        PlayerPrefs.SetFloat(enemy.GetComponent<Enemy>().enemyName + "Spawned", spawned);
        
        //foreach(GameObject tower in Towers)
        //{
        //    tower.GetComponent<TowerArcher>().EnemySpawned(enemy);
        //}
        enemy.GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.Checkpoints;


    }


}
