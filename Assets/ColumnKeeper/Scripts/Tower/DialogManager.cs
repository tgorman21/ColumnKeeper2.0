using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField] private List<AudioClip> inLevelClips = new List<AudioClip>();
    [SerializeField] private AudioClip postLevelClip;

    [Header("AudioSource")]
    [SerializeField] private AudioSource trapdoorSource;

    [HideInInspector] public int clipNum = 0;

    private void Start() => Countdown();

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5);
        TriggerInLevelAudio();
    }

    public void TriggerInLevelAudio()
    {
        if(clipNum < inLevelClips.Count)
        {
            trapdoorSource.PlayOneShot(inLevelClips[clipNum]);
            clipNum++;
        }
    }

    public void TriggerPostLevelAudio()
    {
        trapdoorSource.PlayOneShot(postLevelClip);
    }
}
