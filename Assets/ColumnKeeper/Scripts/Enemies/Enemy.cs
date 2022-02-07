using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class Enemy : MonoBehaviour
{
    GameObject towerObj;
    public enum EnemyName { Goblin, Orc, Troll, Skeleton, Lich, Witch, Vampire, Derzin, Ingrar, Zarzog, Xenoria }; //Names of enemies and bosses
    public enum AnimationType { Walk, Attack,Die }; // Type of Animation
    EnemyAI enemyAI;
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

    public AnimationType animationType;

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

    float deathTime;
    float walkTime;
    float attackTime;
    float powerUpTime;
    //public string enemyName; //////specific enemy

    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        towerArcher = GameObject.FindGameObjectWithTag("TowerArcher").GetComponent<TowerArcher>();
        towerObj = GameObject.FindGameObjectWithTag("Tower");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        initialHealth = health;
        initialSpeed = agent.speed; //////Sets initial speed to start speed

        impact = true;
        decay = false;

        enemyNameText.SetText(enemyName.ToString());


        //Animation Times
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Attack":
                    attackTime = clip.length;
                    break;
                case "Walk":
                    walkTime = clip.length;
                    break;
                case "Death":
                    deathTime = clip.length;
                    break;
               
            }
        }
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
            animationType = AnimationType.Die;


        }
    }
   void Die()
    {
        enemyAI.currentState = EnemyAI.BehaviorState.Stop;
        anim.Play("Death");
        StartCoroutine(DeathAnimation());
        
    }
    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(deathTime);
        ScoreText.score += 1;
        Destroy(gameObject);
    }
    //Changes different Types of Animations
    public void TypeofAnimation()
    {
        switch (animationType)
        {
            case AnimationType.Walk:
                //if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 != 0) return; //check if animation is done playing before playing again

                anim.Play("Walk");
                break;

            case AnimationType.Attack:

                anim.Play("Attack");
                break;
            case AnimationType.Die:
                Die();
                break;
            default: Debug.Log("Not an Animation");
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
    public void TowerDamage()
    {
        towerObj.GetComponent<TowerHealth>().DealDamage(damage);
    }

    public void DealDamage(float damage)
    {
        //////Deal Damage
        if (health >= 0)
        {
            health = health - damage;
            healthBar.localScale = new Vector3(health / initialHealth, 1, 1);
            Debug.Log(enemyName + "Health: " + health);
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

