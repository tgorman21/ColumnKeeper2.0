using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOfArrows : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    public int spawnAmount;
    public float yPos;
    bool RainArrows;
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (RainArrows)
        {
            if(t < 20)
            {
                SpawnArrows();
            }
            else if(t> 20)
            {
                RainArrows = false;
            }
        }
    }
    public void Rain()
    {
        RainArrows = true;
        Debug.Log("Rain");
        /*
        for (int i = 0; i < spawnAmount; i++)
        {
            float x = Random.Range(-4, 4);
            float z = Random.Range(-4, 4);
            Vector3 pos = new Vector3(this.transform.position.x + x, this.transform.position.y + yPos, this.transform.position.z + z);
            GameObject arrowInstance = Instantiate(arrow,pos,Quaternion.identity);
            //arrowInstance.transform.position = pos;
            arrowInstance.transform.Rotate(90, 0, 0,Space.World);
            arrowInstance.GetComponent<Rigidbody>().freezeRotation = true;
            arrowInstance.GetComponent<Arrow>().launched = true;
            arrowInstance.GetComponent<Arrow>().Rain(2);
            //arrowInstance.GetComponent<Rigidbody>().velocity = new Vector3(0, -arrowInstance.GetComponent<Arrow>().speed, 0);
            // arrowInstance.GetComponent<Arrow>().trackRotation = false;
            //arrowInstance.GetComponent<Arrow>().throwSmoothingDuration = 0;
            // arrowInstance.GetComponent<Arrow>().throwVelocityScale = 0;
            //arrowInstance.GetComponent<Arrow>().throwAngularVelocityScale = 0;
            //     arrowInstance.GetComponent<Rigidbody>().AddForce(-transform.up * arrowInstance.GetComponent<Arrow>().speed);


        }
        */
    }
    void SpawnArrows()
    {
        float x = Random.Range(-4, 4);
        float z = Random.Range(-4, 4);
        Vector3 pos = new Vector3(this.transform.position.x + x, this.transform.position.y + yPos, this.transform.position.z + z);
        GameObject arrowInstance = Instantiate(arrow, pos, Quaternion.identity);
        //arrowInstance.transform.position = pos;
        arrowInstance.transform.Rotate(90, 0, 0, Space.World);
        arrowInstance.GetComponent<Rigidbody>().freezeRotation = true;
        arrowInstance.GetComponent<Arrow>().launched = true;
        arrowInstance.GetComponent<Arrow>().Rain(2);
    }
   
}
