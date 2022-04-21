using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFire : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            other.GetComponent<ArrowType>().turnonFire = true;
        }
    }

}
