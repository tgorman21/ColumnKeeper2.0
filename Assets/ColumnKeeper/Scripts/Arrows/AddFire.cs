using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
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
            arrowFire.transform.localPosition = new Vector3(tip.transform.localPosition.x, tip.transform.localPosition.y + 0.40f, tip.transform.localPosition.z - 0.10f);
            arrowFire.transform.parent = other.transform;
        }
    }

}
