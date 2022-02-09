using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Collider attackCollider;

    private Enemy enemy;
    
    private void Start()
    {
        attackCollider = GetComponent<Collider>();
        attackCollider.enabled = false;

        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().DealDamage(GetComponentInParent<Enemy>().damage);
        }
    }
}
