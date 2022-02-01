using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Enemy enemy;
    public Collider attackCollider;
    // Start is called before the first frame update
    void Start()
    {
        attackCollider = GetComponent<Collider>();
        attackCollider.enabled = false;
        enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower"))
        {
            enemy.TowerDamage(other.gameObject);
            attackCollider.enabled = false;
        }
    }
}
