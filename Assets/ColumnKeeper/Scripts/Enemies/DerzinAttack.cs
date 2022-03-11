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
    [SerializeField] float throwForce;
    Vector3 force;
    GameObject towerPos;
    float distanceFromTower;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("TowerPos") != null)
            towerPos = GameObject.FindGameObjectWithTag("TowerPos");
        if(GetComponent<Enemy>() != null)
        {
            enemy = GetComponent<Enemy>();
            damage = enemy.damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        derzinHand.transform.LookAt(towerPos.transform.position);
        RaycastHit hit;
        if (Physics.Raycast(derzinHand.transform.position, derzinHand.transform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("TowerPos"))
            {
                distanceFromTower = hit.distance;
               
                Debug.Log(distanceFromTower);
            }
           
        }
    }
    public void GoblinManager()
    {
        goblinObj.SetActive(!goblinObj.activeSelf);
        goblinHand.SetActive(!goblinObj.activeSelf);
    }

    public void Throw()
    {
        goblinHand.SetActive(false);
        GameObject goblin = Instantiate(goblinThrow);
        goblin.transform.position = derzinHand.transform.position;
        goblin.transform.rotation = derzinHand.transform.rotation;
        //Enemy Reference 
        goblin.GetComponent<EnemyAI>().enabled = false;
        goblin.GetComponent<NavMeshAgent>().enabled = false;
        goblin.GetComponent<Rigidbody>().isKinematic = false;
        goblin.GetComponent<Enemy>().enemyName = Enemy.EnemyName.ThrowableGoblin;
        goblin.GetComponent<Enemy>().damage = damage;
        goblin.GetComponent<MeshCollider>().enabled = false;
        goblin.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
        Collider[] colliders = goblin.GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            if(col.gameObject.transform.parent != null)
            col.enabled = false;
        }
        
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
        work = goblin.GetComponent<Rigidbody>().mass * a * displacement;

        force = work/displacement * Time.deltaTime;
        goblin.GetComponent<Rigidbody>().mass = (goblin.GetComponent<Rigidbody>().mass * Mathf.Sqrt(displacement))/9.8f;
        //Throw
        goblin.GetComponent<Rigidbody>().AddForce(transform.forward * force);
        
    }

}
