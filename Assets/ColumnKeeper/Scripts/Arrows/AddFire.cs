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
            GameObject fireEffect = other.transform.GetChild(0).GetChild(1).gameObject;
            fireEffect.transform.GetChild(0).gameObject.GetComponent<Light>().enabled = true;
            fireEffect.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();
        }
    }

}
