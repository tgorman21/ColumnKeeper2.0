﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class Enemy : MonoBehaviour
{
    GameObject towerObj;
    public enum EnemyName { Goblin, Orc, Troll, Skeleton, Lich, Witch, Vampire, Derzin, Ingrar, Zarzog, Xenoria }; //Names of enemies and bosses
    public enum AnimationType { Walk, Attack, Die, powerUp }; // Type of Animation
    EnemyAI enemyAI;
    [Header("Enemy Info")]
    public EnemyName enemyName;
    public float health; ////// health points
    [SerializeField] public float damage; ////// damage
    public float publicDamage;
    public int lane = 0;
    public Transform centerMass;

    [Header("UI References")]
    public RectTransform healthBar; //////bar for health
    public TextMeshProUGUI enemyNameText;
    public TextMeshProUGUI damageTakenText; //Text for damage taken
    public GameObject damageText;
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
        damageTakenText.enabled = false;
        enemyAI = GetComponent<EnemyAI>();
        towerArcher = GameObject.FindGameObjectWithTag("TowerArcher").GetComponent<TowerArcher>();
        towerObj = GameObject.FindGameObjectWithTag("Tower");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        initialHealth = health;
        initialSpeed = agent.speed; //////Sets initial speed to start speed
        publicDamage = damage;
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
                default:
                    if(clip.name == "powerUp")
                    {
                        powerUpTime = clip.length;
                    }
                    break;
            }
        }
        if (enemyName == EnemyName.Orc)
            animationType = AnimationType.powerUp;
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
            enemyAI.currentState = EnemyAI.BehaviorState.Stop;
            animationType = AnimationType.Die;


        }
    }
    void Die()
    {
        enemyAI.currentState = EnemyAI.BehaviorState.Stop;
        anim.Play("Death");
        StartCoroutine(AnimationTimer(deathTime, 1));

    }
    IEnumerator AnimationTimer(float time, int score)
    {
        yield return new WaitForSeconds(time);
        ScoreText.score += score;
        if (score > 0)
            Destroy(gameObject);
        else if (score < 1)
        {
            if (agent.isStopped)
            {
                agent.isStopped = false;
                animationType = AnimationType.Walk;
            }
        }
        
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
                        Attack();
                        break;
                    case AnimationType.Die:
                        Die();
                        break;
                        case AnimationType.powerUp:
                        PowerUp();
                        break;
                    default:
                        Debug.Log("Not an Animation");
                        break;
                }
                
        }

        
    
    void PowerUp()
    {
        anim.Play("powerUp");
        agent.isStopped = true;
        StartCoroutine(AnimationTimer(attackTime, 0));
    }
    void Attack()
    {
        anim.Play("Attack");
        StartCoroutine(AnimationTimer(attackTime, 0));
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
            damageTakenText.enabled = true;
            health = health - damage;
            healthBar.localScale = new Vector3(health / initialHealth, 1, 1);
            //HpSplash indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<HpSplash>();
            //indicator.SetDamageText(damage);
            damageTakenText.SetText(damage.ToString("-##"));
            StartCoroutine(HideText());
            Debug.Log(enemyName + "Health: " + health);
        }
    }
    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2);
        damageTakenText.enabled = false;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if(other.GetComponent<Enemy>().enemyName == EnemyName.Skeleton || other.GetComponent<Enemy>().enemyName == EnemyName.Goblin)
            {
                float newDamage = other.GetComponent<Enemy>().damage * 0.2f;
                newDamage += other.GetComponent<Enemy>().damage;
                other.GetComponent<Enemy>().damage = newDamage;
            }
                
            
        }
    }
}

