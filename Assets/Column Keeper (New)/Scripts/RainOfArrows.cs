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
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + yPos, transform.position.z);
        //arrowInstance.transform.Rotate(90, 0, 0, Space.World); //This Works
        
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject arrowInstance = Instantiate(arrow, pos, transform.rotation = Quaternion.Euler(90,0,0));
            
            arrowInstance.GetComponent<Rigidbody>().AddForce(-transform.up * arrowInstance.GetComponent<Arrow>().speed, ForceMode.Acceleration);
            arrowInstance.GetComponent<Arrow>().launched = true;

        }
    }
   
}
