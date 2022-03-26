using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LichSpawner : MonoBehaviour
{
    [SerializeField] GameObject skeletonObj;
    Transform towerPos;
    [SerializeField] float spawmRate;
    float t;
    [SerializeField] Transform skeletonPos;
    // Start is called before the first frame update
    void Start()
    {
        towerPos = GameObject.FindGameObjectWithTag("Tower").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t > spawmRate)
        {
            Spawn();
            t = 0;
        }
    }
    private void Spawn()
    {
        GameObject skeleton = Instantiate(skeletonObj, skeletonPos.position,Quaternion.identity,transform.parent = null);
        skeleton.GetComponent<NavMeshAgent>().speed = 3.5f;
        skeleton.GetComponent<NavMeshAgent>().autoBraking = false;
        skeleton.GetComponent<Enemy>().damage = skeleton.GetComponent<Enemy>().damage / 2;
        skeleton.GetComponent<EnemyAI>().towerPos = towerPos;
        skeleton.GetComponent<EnemyAI>().Equals(GetComponent<EnemyAI>());
        skeleton.GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.SeekTower;
    }
}
