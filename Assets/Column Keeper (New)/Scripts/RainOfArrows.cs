using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOfArrows : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    public int spawnAmount;
    public float yPos;
    bool RainArrows;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rain()
    {
        Debug.Log("Rain");
        
        for (int i = 0; i < spawnAmount; i++)
        {
            float x = Random.Range(-2, 2);
            float z = Random.Range(-2, 2);
            Vector3 pos = new Vector3(this.transform.position.x + x, this.transform.position.y + yPos, this.transform.position.z + z);
            GameObject arrowInstance = Instantiate(arrow,pos,Quaternion.identity);
            //arrowInstance.transform.position = pos;
            arrowInstance.transform.Rotate(90, 0, 0,Space.World);
            arrowInstance.GetComponent<Rigidbody>().freezeRotation = true;
            arrowInstance.GetComponent<Arrow>().launched = true;
            arrowInstance.GetComponent<Rigidbody>().velocity = new Vector3(0, arrowInstance.GetComponent<Arrow>().speed, 0);
            // arrowInstance.GetComponent<Arrow>().trackRotation = false;
            //arrowInstance.GetComponent<Arrow>().throwSmoothingDuration = 0;
            // arrowInstance.GetComponent<Arrow>().throwVelocityScale = 0;
            //arrowInstance.GetComponent<Arrow>().throwAngularVelocityScale = 0;
            //     arrowInstance.GetComponent<Rigidbody>().AddForce(-transform.up * arrowInstance.GetComponent<Arrow>().speed);


        }
    }
   
}
