using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string enemyName; //specific enemy
    [SerializeField]private float health; // health points
    public float damage; // damage
    Rigidbody rb; //rigidbody
    NavMeshAgent agent; //movement
    public RectTransform healthBar; //bar for health
    float t = 0; //timer
    public bool function; //testing function
    bool decay; // DOT bool
    float decayDamage; //DOT 
    bool impact; //initial hit damage
    public float initialSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        decay = false;
        impact = true;
        initialSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Testing
        //if (function)
        //{
        //    FireDamage(10, 0.16f);

        //}

        ////// Death Condition 
        if (health <= 0)
        {
            ScoreText.score += 1;
            Destroy(gameObject);
        }
        
    }
    private void FixedUpdate()
    {
        //////Timer decay
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
                impact = true; ////// Trigger impact damage once
            }


        }

       
    }
    public void DealDamage(float damage)
    {

        //////Deal Damage
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

        //////Condition for impact Damage to happen
        if (impact)
        {
            DealDamage(impactDamage);
            impact = false;
        }
        
        decay = true;
        
        function = false; ////// Testing Bool
       
    }

    public void IceArrow(float speedDamp)
    {
        
            agent.speed *= speedDamp;
        
        
        StartCoroutine(IceArrowSpeed());
    }
    IEnumerator IceArrowSpeed()
    {
        yield return new WaitForSeconds(10);
        agent.speed = initialSpeed;
    }
    public void HypnoArrow()
    {

    }

    public void HealingArrow()
    {

    }
}

