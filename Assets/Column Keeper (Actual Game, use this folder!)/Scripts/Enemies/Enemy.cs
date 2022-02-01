using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class Enemy : MonoBehaviour
{
    //public string enemyName; //////specific enemy

    Animator anim;
    public enum EnemyName { Goblin,Orc, Troll, Skeleton, Lich, Witch, Vampire, Derzin, Ingrar, Zarzog, Xenoria }; //Names of enemies and bosses
    public EnemyName enemyName;
    public Transform centerMass;
    public enum AnimationType { Walk, Attack }; // Type of Animation
    public AnimationType animationType;
    TowerArcher towerArcher;
    public float health; ////// health points
    [SerializeField] private float damage; ////// damage
    Rigidbody rb; //////rigidbody
    NavMeshAgent agent; //////movement
    public RectTransform healthBar; //////bar for health
    public TextMeshProUGUI enemyNameText;
    float initialHealth;
    float t = 0; //////timer
    public bool function; /////testing function
    bool decay; ///// DOT bool
    float decayDamage; //////DOT 
    bool impact; //////initial hit damage
    public float initialSpeed; //////Initial speed
    public int lane = 0;
    // Start is called before the first frame update
    void Start()
    {
        towerArcher = GameObject.FindGameObjectWithTag("TowerArcher").GetComponent<TowerArcher>();
        rb = GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        initialHealth = health;
        agent = GetComponent<NavMeshAgent>();
        decay = false;
        impact = true;
        enemyNameText.SetText(enemyName.ToString());
        //////Sets initial speed to start speed
        initialSpeed = agent.speed;
    }

    //Changes different Types of Animations
   public void TypeofAnimation()
    {
        switch (animationType)
        {
            case AnimationType.Walk:
                anim.Play("Walk");
               
                break;
            case AnimationType.Attack:
                anim.Play("Attack");
                if (GetComponentInChildren<EnemyAttack>().attackCollider != null)
                {
                    GetComponentInChildren<EnemyAttack>().attackCollider.enabled = true;
                }
                
                //GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.Stop;
                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
        //Enemy Controller for animations
        switch (enemyName)
        {
            case EnemyName.Goblin:
                TypeofAnimation();
                break;
            case EnemyName.Orc:
                TypeofAnimation();
                break;
            case EnemyName.Troll:
                TypeofAnimation();
                break;
            case EnemyName.Skeleton:
                TypeofAnimation();
                break;
            case EnemyName.Lich:
                TypeofAnimation();
                break;
            case EnemyName.Witch:
                TypeofAnimation();
                break;
            case EnemyName.Vampire:
                TypeofAnimation();
                break;

            case EnemyName.Derzin:
                TypeofAnimation();
                break;
            case EnemyName.Ingrar:
                TypeofAnimation();
                break;
            case EnemyName.Zarzog:
                TypeofAnimation();
                break;
            case EnemyName.Xenoria:
                TypeofAnimation();
                break;

            default: Debug.Log("Not an enemy");
                break;
        }
        //Testing
        //if (function)
        //{
        //    FireDamage(10, 0.16f);

        //}

        ////// Death Condition 
        if (health <= 0)
        {
            //towerArcher.RemoveEnemy(gameObject);
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
            if (t > 2.5f)
            {
                agent.speed = initialSpeed;


            }
            else if (t < 5.1f)
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

    //////Damages Tower
    public void TowerDamage(GameObject tower)
    {
        tower.GetComponent<TowerHealth>().DealDamage(damage);
    }

    public void DealDamage(float damage)
    {
        //////Deal Damage
        if (health >= 0)
        {
            health = health - damage;
            healthBar.localScale = new Vector3(health / initialHealth, 1, 1);
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
        //////Damp Speed
        agent.speed = speedDamp * agent.speed;

        StartCoroutine(IceArrowSpeed());
    }

    IEnumerator IceArrowSpeed()
    {
        //////Set speed back to initial
        yield return new WaitForSeconds(10);
        agent.speed = initialSpeed;
    }

    public void HypnoArrow()
    {
        GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.Hypno;
    }

    public void HealingArrow()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tower"))
        {
            TowerDamage(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

