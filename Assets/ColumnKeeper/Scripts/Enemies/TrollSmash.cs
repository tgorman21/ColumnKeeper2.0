using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollSmash : MonoBehaviour
{
    public ParticleSystem Smash;
    public ParticleSystem TrollDie;
    private float HP;
    private float t = 0;
    private void Start()
    {
        HP = gameObject.GetComponent<Enemy>().health;
    }
    private void Update()
    {
        if (HP >= 200) return;

        t += Time.deltaTime;

        if(t >= 1)
        {
            t = 0;
            HP += 3;
            Debug.Log(HP);
                Debug.Log(3);
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