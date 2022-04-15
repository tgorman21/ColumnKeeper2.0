using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    public class DerzinAttack : MonoBehaviour
    {
        [SerializeField] GameObject goblinObj;
        [SerializeField] GameObject goblinHand;
        [SerializeField] GameObject goblinThrow;
        [SerializeField] Transform derzinHand;
        Enemy enemy;
        [HideInInspector] float throwForce;
        Vector3 force;
        GameObject towerPos;
        float distanceFromTower;
        private float damage;
        [HideInInspector] public bool activated;
        [SerializeField] float cooldown;
        float t;
        // Start is called before the first frame update
        void Start()
        {
            if (GameObject.FindGameObjectWithTag("PlayerPos") != null)
                towerPos = GameObject.FindGameObjectWithTag("PlayerPos");
            if (GetComponent<Enemy>() != null)
            {
                enemy = GetComponent<Enemy>();
                damage = enemy.damage;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (activated)
            {
                t += Time.deltaTime;
                if (t > cooldown)
                {
                    GetComponent<Enemy>().animationType = Enemy.AnimationType.Throw;
                    t = 0;
                }
            }
            derzinHand.transform.LookAt(towerPos.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(derzinHand.transform.position, derzinHand.transform.forward, out hit))
            {
               
                    distanceFromTower = Vector3.Distance(towerPos.transform.position, transform.position);
                    if (GetComponent<Enemy>().enemyName == Enemy.EnemyName.Derzin)
                    {
                        if (distanceFromTower < 15)
                        {
                            hit.collider.gameObject.GetComponentInParent<TowerHealth>().DealDamage(1000);
                        }
                    }

                    if (GetComponent<Enemy>().enemyName == Enemy.EnemyName.Troll)
                    {
                        if (distanceFromTower < 37)
                        {
                            GetComponent<EnemyAI>().currentState = EnemyAI.BehaviorState.Stop;
                        }
                    }
                    //Debug.Log(distanceFromTower);
                }
                else if (hit.collider.CompareTag("PlayerPos"))
                {
                    hit.collider.GetComponent<StunPlayer>().Stun();
                }

            
        }
        public void GoblinManager()
        {
            if (goblinObj != null)
            {
                goblinObj.SetActive(!goblinObj.activeSelf);
            }
            if (goblinHand != null)
            {
                goblinHand.SetActive(!goblinHand.activeSelf);
            }

        }

        public void Throw()
        {
            if (goblinHand != null)
                goblinHand.SetActive(false);
            GameObject goblin = Instantiate(goblinThrow);
            goblin.transform.position = derzinHand.transform.position;
            goblin.transform.rotation = derzinHand.transform.rotation;
            //Enemy Reference
            if (goblin.GetComponent<EnemyAI>() != null)
                goblin.GetComponent<EnemyAI>().enabled = false;
            if (goblin.GetComponent<NavMeshAgent>() != null)
                goblin.GetComponent<NavMeshAgent>().enabled = false;
            goblin.GetComponent<Rigidbody>().isKinematic = false;
            if (goblin.GetComponent<Enemy>().enemyName != Enemy.EnemyName.Rock)
                goblin.GetComponent<Enemy>().enemyName = Enemy.EnemyName.ThrowableGoblin;
            goblin.GetComponent<Enemy>().damage = damage;
            if (goblin.GetComponent<Enemy>().enemyName != Enemy.EnemyName.Rock)
            {
                goblin.GetComponent<MeshCollider>().enabled = false;
                Collider[] colliders = goblin.GetComponentsInChildren<Collider>();
                foreach (Collider col in colliders)
                {
                    if (col.gameObject.transform.parent != null)
                        col.enabled = false;
                }
            }
            goblin.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;

            goblin.GetComponent<Rigidbody>().drag = 0.1f;
            goblin.GetComponent<Rigidbody>().angularDrag = 1;
            goblin.GetComponent<Rigidbody>().mass = 2.5f;
            //Throw Force
            //Debug.Log(goblin.GetComponent<Rigidbody>().velocity);
            float displacement = 0;
            float a = 0;
            float force = 0;
            displacement = distanceFromTower - goblinHand.transform.position.magnitude * Time.deltaTime * Time.deltaTime;
            a = (2 * displacement) / (Time.deltaTime * Time.deltaTime);
            float work = 0;
            goblin.GetComponent<Rigidbody>().mass = (goblin.GetComponent<Rigidbody>().mass * Mathf.Sqrt(displacement)) / 9.8f;

            work = goblin.GetComponent<Rigidbody>().mass * a * displacement;

            force = work / displacement;
            //Throw
            goblin.GetComponent<Rigidbody>().AddForce(transform.forward * force * 2 * Time.deltaTime);
            if (goblin.GetComponent<Enemy>().enemyName != Enemy.EnemyName.Rock)
                GetComponent<Enemy>().animationType = Enemy.AnimationType.Idle;
            if (goblin.GetComponent<Enemy>().enemyName == Enemy.EnemyName.Rock)
                GetComponent<Enemy>().animationType = Enemy.AnimationType.Walk;
        }

    }
