using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPedestal : MonoBehaviour
{
    Transform bowOrg;

    [SerializeField] GameObject bow;
    Transform bowTrasform;
    [SerializeField] Transform socketPos;
    [SerializeField] float rotationSpeed;
    [Header("Axis in which it rotates")]
    Transform playerTransform;
    float playerDist;
    float bowDist;
    [SerializeField] float safeDist;
    [SerializeField] Vector3 axis;
    GameObject bowObj;
    bool rotateBow;
    
    private void Start()
    {
        bowOrg = bow.GetComponent<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rotateBow = true;
        bowObj = Instantiate(bow, socketPos.position, Quaternion.identity, transform.parent = socketPos);
        bowTrasform = GameObject.FindGameObjectWithTag("Bow").GetComponent<Transform>();
    }

    private void Update()
    {
        playerDist = Vector3.Distance(playerTransform.position, transform.position);
        bowDist = Vector3.Distance(bowTrasform.position, transform.position);
        
        if (playerDist < safeDist)
        {
            rotateBow = false;
            bowObj.transform.parent = null;
        }
        else
        {
            rotateBow = true;
            bowObj.transform.parent = socketPos;
        }

        if(bowDist > 0)
        {
            rotateBow = false;
            
            bowObj.transform.parent = null;
        }

        if(rotateBow)
            socketPos.transform.RotateAround(socketPos.transform.position, axis, rotationSpeed);
    }
    
    
    
}
