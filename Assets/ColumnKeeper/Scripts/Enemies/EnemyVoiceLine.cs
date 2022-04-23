using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVoiceLine : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] List<AudioClip> voiceLines = null;
    [SerializeField] private float voiceLineRate;
    private bool play;
    private float t;

    private void Start()
    {
        t = 0;
        audioSource = GetComponent<AudioSource>();
        audioSource.minDistance = 5;
        audioSource.maxDistance = 75;
        play = false;
    }

    private void Update()
    {
        t += Time.deltaTime;
        if (t > voiceLineRate && !play && voiceLines.Count != 0)
        {
            PlayVoiceLine(voiceLines);
        }
    }

    //Plays the voice line
    private void PlayVoiceLine(List<AudioClip> clips)
    {
        int r = Randomize();
        StartCoroutine(ResetVoiceLine(clips[r].length, clips, r));
        
       
    }
    IEnumerator ResetVoiceLine(float t, List<AudioClip> clips, int r)
    {
        play = true;
        
        if (!audioSource.isPlaying && voiceLines.Count != 0) audioSource.PlayOneShot(clips[r]);
        yield return new WaitForSeconds(t);
        RemoveVoiceLine(clips, r);
        play = false;
        this.t = 0;
    }

    //Randomizes Next audio clip to play
    private int Randomize()
    {
        int randomNumber = Random.Range(0, voiceLines.Count);
        return randomNumber;
    }

    //Removes that voice line from list 
    private void RemoveVoiceLine(List<AudioClip> newList, int index)
    {
        newList.Remove(newList[index]);
        voiceLines = newList;

    }
}
