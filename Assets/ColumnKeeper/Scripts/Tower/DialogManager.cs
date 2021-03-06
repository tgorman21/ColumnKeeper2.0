using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private List<AudioClip> inLevelClips = new List<AudioClip>();
    [SerializeField] private AudioClip postLevelClip;

    [Header("Audio Source")]
    [SerializeField] private AudioSource trapdoorSource;
    [SerializeField] private AudioSource musicManager;

    [HideInInspector] public int clipNum = 0;

    private void Start()
    {
        StartCoroutine(Countdown());
    }
    private void Update()
    {
        if (trapdoorSource.isPlaying)
        {
            musicManager.volume = 0.4f;
        }
        else
        {
            musicManager.volume = 0.7f;
        }
    }
    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
        TriggerInLevelAudio();
    }

    public void TriggerInLevelAudio()
    {
        if (trapdoorSource.isPlaying)
        {
            StartCoroutine(WaitForClipToEnd());
        }
        else
        {
            if (clipNum < inLevelClips.Count)
            {
                trapdoorSource.PlayOneShot(inLevelClips[clipNum]);
                clipNum++;
                Debug.Log(inLevelClips);
            }
        } 
    }

    private IEnumerator WaitForClipToEnd()
    {
        yield return new WaitWhile(() => trapdoorSource.isPlaying);
        TriggerInLevelAudio();
    }

    public void TriggerPostLevelAudio()
    {
        if(!trapdoorSource.isPlaying) trapdoorSource.PlayOneShot(postLevelClip);
    }
}
