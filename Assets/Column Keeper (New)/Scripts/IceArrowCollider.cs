using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceArrowCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (col.gameObject.GetComponent<Enemy>() != null)
            {
                //////Damp Speed For Enemy
                col.gameObject.GetComponent<Enemy>().IceArrow(GetComponentInParent<IceArrow>().DampSpeed);
                col.gameObject.GetComponent<Enemy>().DealDamage(GetComponentInParent<IceArrow>().damageIce);

            }
        }
    }
}
