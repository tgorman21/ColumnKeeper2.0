using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShower : MonoBehaviour
{
    [SerializeField] GameObject meteorShower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shower(float damage, Vector3 pos)
    {
        GetComponentInChildren<MeteorDamage>().damage = damage;
        GameObject shower = Instantiate(meteorShower);
        shower.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
