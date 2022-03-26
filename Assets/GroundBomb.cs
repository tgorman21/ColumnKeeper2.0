using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBomb : MonoBehaviour
{
    public float impactDamage;
    public float decayDamage;

    //[SerializeField]private GameObject explosionObj;
    private ParticleSystem ps;
    [SerializeField] private GameObject explosionPos;
    private BlastWave bw;
    // Start is called before the first frame update
    void Start()
    {
       
        ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        bw = transform.GetChild(0).GetChild(2).GetComponent<BlastWave>();
        //foreach (GameObject explosionSize in explosionPos.GetComponentsInChildren<GameObject>())
        //{
        //    explosionSize.transform.localScale = new Vector3(PlayerPrefs.GetFloat("FireSize"), PlayerPrefs.GetFloat("FireSize"), PlayerPrefs.GetFloat("FireSize"));
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    public void FireDamage(Enemy enemy)
    {
        enemy.DealDamage(impactDamage);
        for (int i = 0; i < 5; i++)
        {
            enemy.DealDamage(decayDamage);
        }
        //Destroy(this.gameObject);
    }

    public void Explode(Vector3 rot, Vector3 pos)
    {
        //explosionPos.transform.position = new Vector3(pos.x, pos.y, pos.z);
        bw.transform.eulerAngles = Vector3.right * 90;
        StartCoroutine(bw.Blast());
        ps.Play();
        StartCoroutine(DestroyBomb());
        //Debug.Log("Hit");
    }
    IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(ps.main.duration);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            Explode(transform.eulerAngles, explosionPos.transform.position);
        }
    }
}
