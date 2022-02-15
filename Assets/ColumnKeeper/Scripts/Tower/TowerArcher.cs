using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArcher : MonoBehaviour
{
    //[SerializeField] GameObject testObj;
    [SerializeField] Transform aimTransform;
    [SerializeField] GameObject arrowObj;
    float t = 0;
    [SerializeField] float minimumTime;
    [SerializeField] float maxTime;
    [SerializeField] float arrowSpeed;
    [SerializeField] float arrowForce;
    [SerializeField] float distToShoot = 100;
    public float arrowDamage;
    float fireRate;
    public List<GameObject> lane1 = new List<GameObject>();
    public List<GameObject> lane2 = new List<GameObject>();
    public List<GameObject> lane3 = new List<GameObject>();
    int i = 0;
    public enum Lane { Lane1, Lane2, Lane3 };
    //[SerializeField] List<GameObject> enemies;
    public Lane lane;
    int closestEnemy;

    EnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>() != null)
        {
            enemySpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        }
        
        closestEnemy = -1;
        fireRate = Random.Range(minimumTime, maxTime);
    }
    public void EnemySpawned(GameObject enemy)
    {
        //enemies.Add(enemy);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Checks if enemies in spawner are all destroyed
        if(enemySpawner.enemyCheck != null)
        {
            CheckEnemy(enemySpawner.enemyCheck);
        }

        //Uncomment if Archers dont shoot enemies on wave levels
        if (enemySpawner.archersShoot)
        {
            switch (lane)
            {
                case Lane.Lane1:
                    CheckEnemy(lane1);
                    break;
                case Lane.Lane2:
                    CheckEnemy(lane2);
                    break;
                case Lane.Lane3:
                    CheckEnemy(lane3);
                    break;
            }

            if (lane1 != null || lane2 != null || lane3 != null)
            {


                t += Time.deltaTime;
                if (t > fireRate)
                {

                    switch (lane)
                    {
                        case Lane.Lane1:
                            ShootArrow(lane1);
                            break;
                        case Lane.Lane2:
                            ShootArrow(lane2);
                            break;
                        case Lane.Lane3:
                            ShootArrow(lane3);
                            break;
                    }
                }
            }
        }

    }

    void CheckEnemy(List<GameObject> enemies)
    {
        //closestEnemy = -1;
        //Debug.Log(enemies.Count);
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.Remove(enemies[i]);
                //closestEnemy -= 1;
            }
        }


    }
    void ShootArrow(List<GameObject> enemies)
    {

        fireRate = Random.Range(minimumTime, maxTime);
        float dist = distToShoot;
        //closestEnemy = -1;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.Remove(enemies[i]);
                //closestEnemy -= 1;
            }
            else if (enemies[i] != null)
            {
                t = 0;
                float distance = Vector3.Distance(transform.position, enemies[i].transform.position);
                //Add min distance to shoot
                // Rotation clamp?
                if (distance < dist)
                {
                    dist = distance;
                    
                    do
                    {

                        closestEnemy = Random.Range(0, enemies.Count);



                    } while (enemies[closestEnemy] == null);
                    Transform centerMass = enemies[closestEnemy].GetComponent<Enemy>().centerMass;
                    //Transform enemyPos;
                    //enemyPos.position = new Vector3(enemies[closestEnemy].transform.position.x, enemies[closestEnemy].transform.position.y + 0.25f, enemies[closestEnemy].transform.position.y);
                    //enemyPos.rotation = enemies[closestEnemy].transform.rotation;
                    if (enemies[closestEnemy] != null)
                    {
                        transform.LookAt(centerMass);
                    }
                    else
                        closestEnemy = Random.Range(0, enemies.Count);
                    if (transform.rotation.y <= 45 && transform.rotation.y >= -45)
                    {
                        RaycastHit hit;
                        if (Physics.Raycast(aimTransform.transform.position, aimTransform.transform.forward, out hit))
                        {
                            if (hit.collider.gameObject.CompareTag("Enemy"))
                            {
                                //hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                                GameObject arrow = Instantiate(arrowObj, aimTransform);
                                arrow.GetComponent<ArrowType>().damage = arrowDamage;
                                arrow.GetComponent<Arrow>().speed = arrowSpeed;
                                arrow.GetComponent<Arrow>().launched = true;
                                arrow.GetComponent<Arrow>().Rain(arrowForce);

                                Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
                                //Debug.Log(testObj.transform.position);
                            }
                            else
                            {
                                //Debug.DrawRay(aimTransform.transform.position, aimTransform.transform.forward * 1000, Color.white);
                            }

                        }
                    }
                }
            }
        }

        //Debug.Log("Distance between: " + enemies[i].gameObject.name + " and " + this.gameObject.name + " = " + distance);
        //Debug.Log(enemies[closestEnemy].gameObject.name + " Is the closest");
    }
}
