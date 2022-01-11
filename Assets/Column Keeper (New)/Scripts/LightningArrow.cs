using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningArrow : MonoBehaviour
{
    [SerializeField] GameObject LightningCloud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightningStrike()
    {
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + 25, this.transform.position.z);
        Instantiate(LightningCloud,pos,Quaternion.identity);
    }
}
