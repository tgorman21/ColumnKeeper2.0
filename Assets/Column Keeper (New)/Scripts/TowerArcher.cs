﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArcher : MonoBehaviour
{
    //[SerializeField] GameObject testObj;
    [SerializeField] Transform aimTransform;
    [SerializeField] GameObject arrowObj;
    float t = 0;
    [SerializeField] float minimumTime;
    [SerializeField] float arrowSpeed;
    [SerializeField] float arrowForce;
    [SerializeField] float maxTime;
    public float arrowDamage;
    float fireRate;
    List<GameObject> lane1 = new List<GameObject>();
    List<GameObject> lane2 = new List<GameObject>();
    List<GameObject> lane3 = new List<GameObject>();
    int i = 0;
    public enum Lane { Lane1, Lane2, Lane3 };

    public Lane lane;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = Random.Range(minimumTime, maxTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies != null)
        {
            if (i < enemies.Length)
            {

                switch (enemies[i].gameObject.GetComponent<Enemy>().lane)
                {
                    case 1:
                        lane1.Add(enemies[i]);
                        break;
                    case 2:
                        lane2.Add(enemies[i]);
                        break;
                    case 3:
                        lane3.Add(enemies[i]);
                        break;
                }
                i++;
            }
            else
            {
                i = 0;
            }
         

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
    void ShootArrow(List<GameObject> enemies)
    {
        fireRate = Random.Range(minimumTime, maxTime);
        float dist = float.MaxValue;
        int closestEnemy = -1;
        for (int i = 1; i < enemies.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, enemies[i].transform.position);
            if (distance < dist)
            {
                dist = distance;
                closestEnemy = i;

                transform.LookAt(enemies[closestEnemy].transform);
                if (transform.rotation.y <= 45 && transform.rotation.y >= -45)
                {


                    RaycastHit hit;
                    if (Physics.Raycast(aimTransform.transform.position, aimTransform.transform.forward, out hit))
                    {
                        if (hit.collider.gameObject.CompareTag("Enemy"))
                        {
                            hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                            GameObject arrow = Instantiate(arrowObj, aimTransform);
                            arrow.GetComponent<ArrowType>().damage = arrowDamage;
                            arrow.GetComponent<Arrow>().launched = true;
                            arrow.GetComponent<Arrow>().speed = arrowSpeed;
                            arrow.GetComponent<Arrow>().Rain(arrowForce);

                            Debug.DrawRay(transform.position, transform.forward * 1000, Color.red);
                            //Debug.Log(testObj.transform.position);
                        }
                        else
                        {
                            Debug.DrawRay(aimTransform.transform.position, aimTransform.transform.forward * 1000, Color.white);
                        }

                    }
                }

            }


            Debug.Log("Distance between: " + enemies[i].gameObject.name + " and " + this.gameObject.name + " = " + distance);
            Debug.Log(enemies[closestEnemy].gameObject.name + " Is the closest");
        }

        //Attack enemy
        Debug.Log(enemies.Count);
        t = 0;
    }
}
