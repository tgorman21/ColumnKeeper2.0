using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDamage : MonoBehaviour
{
    [Header("Damage doesn't need to be declared")]
    [Tooltip("This Reads from Meteor Shower Doesn't need to be declared")]
    public float damage;
    bool collided;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            t += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
                //////Damp Speed For Enemy
                DamageOverTime(other.gameObject);
                other.gameObject.GetComponent<Enemy>().DealDamage(damage);

            }
        }
    }
    
    public void DamageOverTime(GameObject enemy)
    {
        collided = true;
        if(t > 1)
        {
            enemy.gameObject.GetComponent<Enemy>().DealDamage(1);
            t = 0;
        }
    }
    
    
}
