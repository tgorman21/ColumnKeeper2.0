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
        if (function)
        {
            FireDamage(10, 0.16f);

        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    private void FixedUpdate()
    {
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
                impact = true;
            }


        }

        Debug.Log(t);
    }
    public void DealDamage(float damage)
    {

        Debug.Log("Deal Damage");
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
        Debug.Log("Fire Damage");
        if (impact)
        {
            DealDamage(impactDamage);
            impact = false;
        }
        
        decay = true;
        //DecayDamage(decayDMG);
        function = false;
        //Destroy(this.gameObject);
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

