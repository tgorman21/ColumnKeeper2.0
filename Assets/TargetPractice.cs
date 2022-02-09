using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    Rigidbody[] targetPieces;
    [SerializeField]float health;
    // Start is called before the first frame update
    void Start()
    {
        targetPieces = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollapseTarget()
    {
        health -= 50;
        if(health <= 0)
        {
            foreach (Rigidbody piece in targetPieces)
            {
                piece.isKinematic = false;
            }
        }
        
    }
}
