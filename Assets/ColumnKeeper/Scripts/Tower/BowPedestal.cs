using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPedestal : MonoBehaviour
{
    [SerializeField] GameObject bow;
    [SerializeField] Transform socketPos;
    [SerializeField] float rotationSpeed;
    [Header ("Axis in which it rotates")]
    [SerializeField] Vector3 axis;
    GameObject bowObj;
    bool rotateBow;
    // Start is called before the first frame update
    void Start()
    {
        rotateBow = true;
        bowObj = Instantiate(bow, socketPos.position, socketPos.rotation, transform.parent = socketPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(rotateBow)
        socketPos.transform.RotateAround(socketPos.transform.position, axis, rotationSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rotateBow = false;
            bowObj.transform.parent = null;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && other.CompareTag("Bow"))
        {
            rotateBow = false;
            bowObj.transform.parent = null;
        }
        else if (other.CompareTag("Player"))
        {
            bowObj.transform.parent = socketPos;
            rotateBow = true;
        }
    }
}
