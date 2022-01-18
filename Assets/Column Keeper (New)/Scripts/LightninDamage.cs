using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightninDamage : MonoBehaviour
{
    public float damage;
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (col.gameObject.GetComponent<Enemy>() != null)
            {
                //////Damp Speed For Enemy
                
                col.gameObject.GetComponent<Enemy>().DealDamage(damage);

            }
        }
    }
}
