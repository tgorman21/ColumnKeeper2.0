using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialog : MonoBehaviour
{
    [SerializeField] private List<AudioClip> characterVoiceLines;
    private AudioSource audioSource;
    int i;

    private void Start()
    {
        i = 0;
        audioSource = GetComponent<AudioSource>();

    }

    public void PlayAudio()
    {
        if(characterVoiceLines.Count != 0)
        {
            audioSource.PlayOneShot(characterVoiceLines[i]);
            i++;
        }
    }
}
