using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Transform towerPos;
    public Transform[] checkpointPos;
    NavMeshAgent agent;
    public float detectionDistance;
    public int checkpointIndex;
    float minDistance = 10;
    float safeDistance = 10;
    
    public enum BehaviorState { SeekTower, Stop, Hypno, Checkpoints, Attack };

    public BehaviorState currentState;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //towerPos = GameObject.FindGameObjectWithTag("tower").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(t);
    }

    private void FixedUpdate()
    {
        if (agent.enabled)
        {
            //Debug.Log(i);
            switch (currentState)
            {
                case BehaviorState.SeekTower:
                    SeekTower();
                    break;
                case BehaviorState.Stop:
                    Stop();
                    break;
                case BehaviorState.Hypno:
                    HypnoEnemy();
                    break;
                case BehaviorState.Checkpoints:
                    SeekCheckpoint();
                    break;
                case BehaviorState.Attack:
                    Attack();
                    break;
                default:
                    Debug.Log("Switch error");
                    break;
            }
        }

    }
    void Attack()
    {
        GetComponent<Enemy>().animationType = Enemy.AnimationType.Attack;
        //agent.isStopped = true;
        //agent.destination = transform.position;

    }
    void SeekTower()
    {
        Vector3 differenceVector = towerPos.transform.position - transform.position;
        //GetComponent<Enemy>().animationType = Enemy.AnimationType.Walk;

        agent.destination = towerPos.transform.position;
        transform.LookAt(towerPos);
        if (differenceVector.magnitude < 4)//Value changes distance to hit tower
        {
            currentState = BehaviorState.Attack;
            
        }
        //Debug.Log(towerPos.transform.position);
    }
    public void HypnoEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float dist = float.MaxValue;
        int closestEnemy = -1;
        for (int i = 1; i < enemies.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, enemies[i].transform.position);
           if(distance < dist)
            {
                dist = distance;
                closestEnemy = i;
            }
            //Debug.Log("Distance between: " + enemies[i].gameObject.name + " and " + this.gameObject.name + " = " + distance);
            //Debug.Log(enemies[closestEnemy].gameObject.name + " Is the closest");
        }
        Vector3 differenceVector = enemies[closestEnemy].transform.position - transform.position;
        agent.destination = enemies[closestEnemy].transform.position;
        if(differenceVector.magnitude < 1)
        {
            currentState = BehaviorState.Attack;
        }
        //////Attack enemy
        Debug.Log(enemies.Length);
    }
    void Stop()
    {
        agent.isStopped = true;
        agent.destination = transform.position;
    }

    void SeekCheckpoint()
    {
        Vector3 differenceVector = checkpointPos[checkpointIndex].transform.position - transform.position;
        //agent.destination = checkpointPos[0].transform.position;
        //if(differenceVector.magnitude)
        //Debug.Log(differenceVector.magnitude);
        //transform.LookAt(checkpointPos[checkpointIndex]);
        agent.SetDestination(checkpointPos[checkpointIndex].transform.position);
        
        //if (differenceVector.magnitude < 3)
        //{
        //    currentState = BehaviorState.SeekTower;
        //}
        //if (GetComponent<Enemy>().animationType != Enemy.AnimationType.powerUp)
            //GetComponent<Enemy>().animationType = Enemy.AnimationType.Walk;


    }
}
