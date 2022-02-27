using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAudio : MonoBehaviour
{
    [SerializeField] PullMeasurer pullMeasurer;
    public AudioSource bowPull;
    public AudioSource bowRelease;
    // Start is called before the first frame update
    void Start()
    {
        pullMeasurer.bowPull = bowPull;
        pullMeasurer.bowRelease = bowRelease;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
