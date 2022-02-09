using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    Rigidbody[] targetPieces;
    [SerializeField]float health;
    [SerializeField] bool test = false;
    // Start is called before the first frame update
    void Start()
    {
        targetPieces = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            CollapseTarget(100);
        }
    }

    public void CollapseTarget(float damage)
    {
        test = false;
        health -= damage;
        if(health <= 0)
        {
            foreach (Rigidbody piece in targetPieces)
            {
                piece.isKinematic = false;
            }
        }
        
    }
}
