using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAudio : MonoBehaviour
{
    [SerializeField] PullMeasurer pullMeasurer;
    public AudioSource bowPull;
    public AudioSource bowRelease;

    void Start()
    {
        pullMeasurer.bowPull = bowPull;
        pullMeasurer.bowRelease = bowRelease;
    }
}
