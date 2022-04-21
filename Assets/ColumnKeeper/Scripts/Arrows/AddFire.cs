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
            Transform tip = other.GetComponent<Arrow>().tip;
            GameObject arrowFire = Instantiate(fire, other.GetComponent<Arrow>().tip);
            arrowFire.transform.position = new Vector3(tip.transform.position.x, tip.transform.position.y - 0.25f, tip.transform.position.z);
            arrowFire.transform.parent = other.transform;
        }
    }

}
