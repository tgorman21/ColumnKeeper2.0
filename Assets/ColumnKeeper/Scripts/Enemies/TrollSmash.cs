using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollSmash : MonoBehaviour
{
    public ParticleSystem Smash;
    void SmashParticles()
    {
        Smash.Play();
     }
}