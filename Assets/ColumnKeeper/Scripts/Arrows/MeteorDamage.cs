using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorDamage : MonoBehaviour
{
    [Header("Damage doesn't need to be declared")]
    [Tooltip("This Reads from Meteor Shower Doesn't need to be declared")]
    public float damage;
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
                //////Damp Speed For Enemy

                other.gameObject.GetComponent<Enemy>().DealDamage(damage);

            }
        }
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
                //////Damp Speed For Enemy

                StartCoroutine(DamageWhileInCollider(other.gameObject));

            }
        }
    }
    */
    IEnumerator DamageWhileInCollider(GameObject enemy)
    {
        yield return new WaitForSeconds(2);
        enemy.gameObject.GetComponent<Enemy>().DealDamage(1);
    }
}
