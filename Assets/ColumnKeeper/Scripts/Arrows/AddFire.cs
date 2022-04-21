using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFire : MonoBehaviour
{
    public GameObject fire;

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
            GameObject fireEffect = other.transform.GetChild(0).GetChild(0).gameObject;
            for(int i =0; i<fireEffect.transform.childCount; i++)
            {
                fireEffect.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

}
