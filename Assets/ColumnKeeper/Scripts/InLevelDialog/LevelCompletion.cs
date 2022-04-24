using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource trapdoorSource; //used for ending level after post dialog is finished

    [Header("References")]
    [SerializeField] private DialogManager dm;

    private GameObject[] wantedBoards;
    private List<GameObject> completedBoards;
    private int numBoards;

    private bool finished = false;
    private bool voiceTriggered = false;
    private bool quitLevel = false;

    private void Start()
    {
        wantedBoards = GameObject.FindGameObjectsWithTag("WantedBoard");
        completedBoards = new List<GameObject>();
        numBoards = wantedBoards.Length;
    }

    private void Update()
    {
        CheckBoards();

        Finished();

        if (voiceTriggered) QuitLevel(); //attempt to quit level once voice has been triggered
    }

    private void CheckBoards()
    {
        //check whether each board is completed
        foreach (GameObject board in wantedBoards)
        {
            if (completedBoards.Contains(board)) continue; //skip this board if already completed

            if (!board.GetComponent<WantedBoardManager>().levelComplete) continue; //skip board if not complete

            completedBoards.Add(board); //board is complete if not skipped
        }

        //check if all boards have been completed
        if (completedBoards.Count == numBoards) finished = true;
    }

    private void Finished()
    {
        if (!finished) return;

        if (voiceTriggered) return; //return if voice has already been triggered

        dm.TriggerPostLevelAudio();
        voiceTriggered = true;
        quitLevel = true;
    }

    private void QuitLevel()
    {
        if (!quitLevel) return;

        if (trapdoorSource.isPlaying) return; //dont quit level until dialog is finished

        quitLevel = false;
        CustomSceneManager.instance.GoToScene("MainMenu");
    }
}
