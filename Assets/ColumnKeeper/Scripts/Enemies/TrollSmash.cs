using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollSmash : MonoBehaviour
{
    public ParticleSystem Smash;
    public ParticleSystem TrollDie;
    void SmashParticles()
    {
        Smash.Play();
     }
    void DieParticles()
    {
        TrollDie.Play();
    }
}