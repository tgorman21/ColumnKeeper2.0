using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Stage1Dialog : MonoBehaviour
{
    public bool challengeComplete = false;

    [Header("XR References")]
    [SerializeField] private XRDirectInteractor directInteractorR;
    [SerializeField] private XRDirectInteractor directInteractorL;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource trapdoorSource; //used for ending level after post dialog is finished
    [SerializeField] private AudioSource musicManager; //used to change music for challenge

    [Header("Challenge Music")]
    [SerializeField] private AudioClip challengeMusic;

    private DialogManager dm;

    private float t = 10;
    private bool startedChallenge = false;

    private void OnEnable()
    {
        directInteractorR.selectEntered.AddListener(ObjectAttached);
        directInteractorL.selectEntered.AddListener(ObjectAttached);
    }

    private void OnDisable()
    {
        directInteractorR.selectEntered.RemoveListener(ObjectAttached);
        directInteractorL.selectEntered.RemoveListener(ObjectAttached);
    }

    private void Start()
    {
        dm = GetComponent<DialogManager>();
    }

    private void ObjectAttached(SelectEnterEventArgs arg0)
    {
        if (dm.clipNum == 1)
        {
            if (!arg0.interactable.CompareTag("Bow")) return;
            dm.TriggerInLevelAudio();
        }

        if (dm.clipNum == 3)
        {
            if (!arg0.interactable.CompareTag("Arrow")) return;
            dm.TriggerInLevelAudio();
        }
    }

    private void Update()
    {
        if(dm.clipNum == 2)
        {
            t -= Time.deltaTime;

            if (t > 0) return;
            dm.TriggerInLevelAudio();
        }

        if(dm.clipNum == 6 && !startedChallenge)
        {
            startedChallenge = true;
            musicManager.clip = challengeMusic;
            musicManager.time = 159; //set playback time to 2:39 for upbeat challenge music
            musicManager.Play();
        }

        if(challengeComplete)
        {
            if (trapdoorSource.isPlaying) return;

            challengeComplete = false; //reset bool to prevent infinite loop
            CustomSceneManager.instance.GoToScene("MainMenu");
        }
    }
}
