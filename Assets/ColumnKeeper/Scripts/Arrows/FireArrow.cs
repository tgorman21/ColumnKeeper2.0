using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour
{
    public float impactDamage;
    public float decayDamage;
    [HideInInspector]public float fireSize;

    //[SerializeField]private GameObject explosionObj;
    private ParticleSystem ps;
    [SerializeField] private Transform explosionPos;
    private BlastWave bw;
    // Start is called before the first frame update
     void Start()
    {
        PlayerPrefs.SetFloat("ImpactDamage", impactDamage);
        PlayerPrefs.SetFloat("DecayDamage", decayDamage);

        ps = transform.GetChild(2).GetComponent<ParticleSystem>();
        bw = transform.GetChild(2).GetChild(2).GetComponent<BlastWave>();
        foreach(Transform explosionSize in explosionPos)
        {
            PlayerPrefs.SetFloat("FireSize", explosionSize.transform.localScale.x);
            fireSize = PlayerPrefs.GetFloat("FireSize");
            explosionSize.localScale = new Vector3(PlayerPrefs.GetFloat("FireSize"), PlayerPrefs.GetFloat("FireSize"), PlayerPrefs.GetFloat("FireSize"));
        }
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
        enemy.DealDamage(PlayerPrefs.GetFloat("ImpactDamage"));
        for(int i = 0; i < 5; i++)
        {
            enemy.DealDamage(PlayerPrefs.GetFloat("DecayDamage"));
        }
        //Destroy(this.gameObject);
    }
  
    public void Explode(Vector3 rot, Vector3 pos)
    {
        //explosionPos.transform.position = new Vector3(pos.x, pos.y, pos.z);
        bw.transform.eulerAngles =  Vector3.right * 90;
        StartCoroutine(bw.Blast());
        ps.Play();
        
        //Debug.Log("Hit");
    }
}
