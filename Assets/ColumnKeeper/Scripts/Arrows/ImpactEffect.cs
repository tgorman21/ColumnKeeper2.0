using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    [SerializeField] private GameObject impactParticles;

    public void TriggerEffect(Vector3 pos, Quaternion rot)
    {
        Instantiate(impactParticles, pos, rot);
    }
}
