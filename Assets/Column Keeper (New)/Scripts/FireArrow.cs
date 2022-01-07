using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour
{
    public float impactDamage;
    public float decayDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Enemy"))
        //{
        //    FireDamage(collision.gameObject.GetComponent<Enemy>());
        //}
    }

    public void FireDamage(Enemy enemy)
    {
        enemy.DealDamage(impactDamage);
        for(int i = 0; i < 5; i++)
        {
            enemy.DealDamage(decayDamage);
        }
        //Destroy(this.gameObject);
    }
}
