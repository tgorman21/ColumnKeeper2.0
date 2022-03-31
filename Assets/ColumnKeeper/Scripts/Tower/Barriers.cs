using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Barriers : MonoBehaviour
{
    [SerializeField]Transform _scale;
    float minY = 0;
    float maxY = 10;
    [SerializeField]bool rise;
    EnemyAI.BehaviorState currentState;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (rise)
        {
            RiseBarrier();
        }
        else
        {
            LowerBarrier();
        }
    }

    public void RiseBarrier()
    {
        _scale.localScale = new Vector3(_scale.localScale.x, maxY, _scale.localScale.z);
    }
    public void LowerBarrier()
    {
        _scale.localScale = new Vector3(_scale.localScale.x, minY, _scale.localScale.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentState = other.GetComponent<EnemyAI>().currentState;
            other.GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.Stop;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyAI>().currentState = currentState;
        }
    }
}
