using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public GameObject belt;
    public GameObject mainCam;
    float YRot;
    float xPos;
    float zPos;

    // Start is called before the first frame update
    void Start()
    {
        mainCam.GetComponent<Transform>();
        belt.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        YRot = mainCam.transform.rotation.eulerAngles.y;
        xPos = mainCam.transform.position.x;
        zPos = mainCam.transform.position.z;
        belt.transform.position = new Vector3(xPos, transform.position.y, zPos);
        belt.transform.eulerAngles = new Vector3(transform.eulerAngles.x, YRot, transform.eulerAngles.z);
    }
}
