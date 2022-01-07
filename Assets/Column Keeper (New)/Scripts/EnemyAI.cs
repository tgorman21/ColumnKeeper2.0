using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Transform towerPos;
    NavMeshAgent agent;
    public float detectionDistance;
    
   
    float minDistance = 10;
    float safeDistance = 10;
    
    public enum BehaviorState { SeekTower, Stop };

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
       
        //Debug.Log(i);
        switch (currentState)
        {
            case BehaviorState.SeekTower:
                SeekTower();
                break;
            case BehaviorState.Stop:
                Stop();
                break;
           
            default:
                Debug.Log("Switch error");
                break;
        }

    }
    void SeekTower()
    {
        //Vector3 differenceVector = towerPos.transform.position - transform.position;
        
            agent.destination = towerPos.transform.position;

        Debug.Log(towerPos.transform.position);


    }
    
    void Stop()
    {

        agent.destination = transform.position;


    }
    
    
}
