using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainOfArrows : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    public int spawnAmount;
    public float yPos;
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
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + yPos, this.transform.position.z);
        Debug.Log(pos);
        //for (int i = 0; i < spawnAmount; i++)
        //{
        GameObject arrowInstance = Instantiate(arrow,pos,Quaternion.identity);
            //arrowInstance.transform.position = pos;
            arrowInstance.transform.Rotate(90, 0, 0,Space.World);
            arrowInstance.GetComponent<Rigidbody>().freezeRotation = true;
            arrowInstance.GetComponent<Arrow>().launched = true;
        arrowInstance.GetComponent<Arrow>().throwAngularVelocityScale = 0;
            arrowInstance.GetComponent<Rigidbody>().AddForce(-transform.up * arrowInstance.GetComponent<Arrow>().speed);


        //}
    }
   
}
