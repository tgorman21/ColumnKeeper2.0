using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour
{
    public float impactDamage;
    public float decayDamage;

    private ParticleSystem ps;

    private BlastWave bw;
    // Start is called before the first frame update
     void Start()
    {
        ps = transform.GetChild(2).GetComponent<ParticleSystem>();
        bw = transform.GetChild(2).GetChild(2).GetComponent<BlastWave>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("Enemy"))
        //{
        //    FireDamage(collision.gameObject.GetComponent<Enemy>());
        //}
        Explode(collision.transform.eulerAngles);
    }

    public void FireDamage(Enemy enemy)
    {
        enemy.DealDamage(impactDamage);
        for(int i = 0; i < 5; i++)
        {
            enemy.DealDamage(decayDamage);
        }
        //Destroy(this.gameObject);
    }

    public void Explode(Vector3 rot)
    {
        bw.transform.eulerAngles =  Vector3.right * 90;
        ps.Play();
        StartCoroutine(bw.Blast());
        Debug.Log("Hit");
    }
}
