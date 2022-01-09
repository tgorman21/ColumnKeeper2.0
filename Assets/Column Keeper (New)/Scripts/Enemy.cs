using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    [SerializeField]private float health;
    public float damage;
    Rigidbody rb;
    NavMeshAgent agent;
    public RectTransform healthBar;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DealDamage(float damage)
    {

        Debug.Log("Deal Damage");
        if (health > 0)
        {
            health = health - damage;
            healthBar.localScale = new Vector3(health / 100, 1, 1);
            if (!rb.isKinematic || !agent.enabled)
            {
                rb.isKinematic = true;
                agent.enabled = true;
            }
        }
    }
    public void Hit(Arrow arrow)
    {
        arrow.GetComponent<FireArrow>().FireDamage(this);
    }
    public void FireDamage(float impactDamage, float decayDamage)
    {
        
        Debug.Log("Fire Damage");
        DealDamage(impactDamage);
        for (int i = 0; i < 5; i++)
        {
            DealDamage(decayDamage);
        }
        
        //Destroy(this.gameObject);
    }

}

