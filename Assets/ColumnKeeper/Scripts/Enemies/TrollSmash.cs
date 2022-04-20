using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollSmash : MonoBehaviour
{
    public ParticleSystem Smash;
    public ParticleSystem TrollDie;
    [SerializeField] private ParticleSystem healingParticles;

    private float HP;
    private float t = 0;
    private float initialHp;

    private void Start()
    {
       
        initialHp = gameObject.GetComponent<Enemy>().health;
        Debug.Log(initialHp);
    }
    private void Update()
    {
        HP = gameObject.GetComponent<Enemy>().health;
        if (HP >= initialHp) return;

        t += Time.deltaTime;
        Debug.Log(t);
        if (t >= 15)
        {
            StartCoroutine(Heal());

        }
    }
    IEnumerator Heal()
    {
        HealingEffect(true);
        gameObject.GetComponent<Enemy>().health = Mathf.Lerp(HP, HP + 5, Time.deltaTime);//Increases health by 5
        yield return new WaitForSeconds(5);
        t = 0;
        HealingEffect(false);

    }
    void HealingEffect(bool state)
    {
        if (state)
            healingParticles.Play();
        else if(!state)
            healingParticles.Stop();
    }

    void SmashParticles()
    {
        Smash.Play();
     }
    void DieParticles()
    {
        TrollDie.Play();
    }
}