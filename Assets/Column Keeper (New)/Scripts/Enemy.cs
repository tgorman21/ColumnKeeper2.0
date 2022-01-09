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
    float t = 0;
    public bool function;
    bool decay;
    float decayDamage;
    bool impact;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        decay = false;
        impact = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Testing
        //if (function)
        //{
        //    FireDamage(10, 0.16f);

        //}

        // Death Condition 
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    private void FixedUpdate()
    {
        //Timer decay
        if (decay)
        {
            t += Time.deltaTime;
            if (t < 5.1f)
            {
                DealDamage(decayDamage);

            }
            else
            {
                decay = false;
                t = 0;
                impact = true; // Trigger impact damage once
            }


        }

       
    }
    public void DealDamage(float damage)
    {

        //Deal Damage
        if (health >= 0)
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
    public void FireDamage(float impactDamage, float decayDMG)
    {

        decayDamage = decayDMG;
        //Debug.Log("Fire Damage");

        //Condition for impact Damage to happen
        if (impact)
        {
            DealDamage(impactDamage);
            impact = false;
        }
        
        decay = true;
        
        function = false; // Testing Bool
       
    }
   //void DecayDamage(float decayDamage)
   // {
   //     decay = true;
   //     if (t % 5 == 0)
   //     {
   //         DealDamage(decayDamage);
            
   //     }
   //     if(t >= 25)
   //     {
   //         decay = false;
   //         t = 0;
   //     }
            
   // }
}

