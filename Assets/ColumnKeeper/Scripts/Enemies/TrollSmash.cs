using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollSmash : MonoBehaviour
{
    public ParticleSystem Smash;
    public ParticleSystem TrollDie;
    [SerializeField] private ParticleSystem healingParticles;

    private float HP;
    private float _t = 0;
    private float initialHp;

    private void Start()
    {
       
        initialHp = gameObject.GetComponent<Enemy>().health;
    }
    private void Update()
    {
        HP = gameObject.GetComponent<Enemy>().health;
        if (HP >= initialHp) return;
        
        
        Debug.Log(_t);
        if (StartHealing(_t))
        {
            StartCoroutine(Heal());
            return;
        }
        _t += Time.deltaTime;
    }
    private bool StartHealing(float t)
    {

        if (t >= 15)
        {
            return true;
        }
        else
            return false;

    }
    IEnumerator Heal()
    {
        HealingEffect(true);
        gameObject.GetComponent<Enemy>().health = Mathf.Lerp(HP, HP + 5, Time.deltaTime);//Increases health by 5
        yield return new WaitForSeconds(5);
        _t = 0;
        HealingEffect(false);

    }
    private void HealingEffect(bool state)
    {
        switch (state)
        {
            case true: if(!healingParticles.isPlaying) healingParticles.Play();
                break;
            case false: healingParticles.Stop();
                break;
        }
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