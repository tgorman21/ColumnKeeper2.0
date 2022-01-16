using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour
{
    public float impactDamage;
    public float decayDamage;

    [SerializeField]private GameObject explosionObj;

    private ParticleSystem ps;

    private BlastWave bw;
    // Start is called before the first frame update
     void Start()
    {
        ps = explosionObj.transform.GetChild(2).GetComponent<ParticleSystem>();
        bw = explosionObj.transform.GetChild(2).GetChild(2).GetComponent<BlastWave>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Enemy"))
        //{
        //    FireDamage(collision.gameObject.GetComponent<Enemy>());
        //}
        Explode(collision.transform.eulerAngles);
    }
    */
    public void FireDamage(Enemy enemy)
    {
        enemy.DealDamage(impactDamage);
        for(int i = 0; i < 5; i++)
        {
            enemy.DealDamage(decayDamage);
        }
        //Destroy(this.gameObject);
    }

    
    public void Explode(Vector3 rot, Vector3 pos)
    {
        pos = new Vector3(pos.x, pos.y + 0.5f, pos.z);
        Instantiate(explosionObj, pos, Quaternion.identity);
        bw.transform.eulerAngles =  Vector3.right * 90;
        StartCoroutine(bw.Blast());
        ps.Play();
        
        Debug.Log("Hit");
    }
}
