using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDamage : MonoBehaviour
{
    [Header("Damage doesn't need to be declared")]
    [Tooltip("This Reads from Meteor Shower Doesn't need to be declared")]
    public float damage;
    bool collided;
    GameObject enemy;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        collided = false;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            t += Time.deltaTime;
            if (t > 1)
            {
                enemy.gameObject.GetComponent<Enemy>().DealDamage(1);
                t = 0;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
                //////Damp Speed For Enemy
                collided = true;
                other.gameObject.GetComponent<Enemy>().DealDamage(damage);
                enemy = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collided = false;
        t = 0;
    }

}
