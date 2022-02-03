using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class Enemy : MonoBehaviour
{
    public enum EnemyName { Goblin, Orc, Troll, Skeleton, Lich, Witch, Vampire, Derzin, Ingrar, Zarzog, Xenoria }; //Names of enemies and bosses
    public enum AnimationType { Walk, Attack }; // Type of Animation

    [Header("Enemy Info")]
    public EnemyName enemyName;
    public float health; ////// health points
    [SerializeField] private float damage; ////// damage
    public int lane = 0;
    public Transform centerMass;

    [Header("UI References")]
    public RectTransform healthBar; //////bar for health
    public TextMeshProUGUI enemyNameText;

    [Header("Dev Tools")]
    public bool function; /////testing function

    [HideInInspector] public AnimationType animationType;

    private TowerArcher towerArcher;
    
    private Animator anim;
    private NavMeshAgent agent; //////movement
    private Rigidbody rb; //////rigidbody
    
    private float initialHealth; //////Initial health
    private float initialSpeed; //////Initial speed

    private bool impact; //////initial hit damage
    private bool decay; ///// DOT bool
    private float decayDamage; //////DOT 

    private float t = 0; //////timer

    //public string enemyName; //////specific enemy

    void Start()
    {
        towerArcher = GameObject.FindGameObjectWithTag("TowerArcher").GetComponent<TowerArcher>();
       
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        initialHealth = health;
        initialSpeed = agent.speed; //////Sets initial speed to start speed

        impact = true;
        decay = false;
        
        enemyNameText.SetText(enemyName.ToString());
    }
    
    private void Update()
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

    //Changes different Types of Animations
    public void TypeofAnimation()
    {
        switch (animationType)
        {
            case AnimationType.Walk:
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 != 0) return; //check if animation is done playing before playing again

                anim.Play("Walk");
                break;

            case AnimationType.Attack:
                if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 != 0) return; //check if animation is done playing before playing again

                anim.Play("Attack");
                if (GetComponentInChildren<EnemyAttack>().attackCollider != null)
                {
                    GetComponentInChildren<EnemyAttack>().attackCollider.enabled = true;
                }

                //GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.Stop;
                break;
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
}

