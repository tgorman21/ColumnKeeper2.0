using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform[] towerPos;
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
        //set destination position
        enemy.GetComponent<EnemyAI>().towerPos = towerPos[pointIndex];
    }
}
