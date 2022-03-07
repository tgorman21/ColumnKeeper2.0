using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    GameObject[] wantedBoards;
    int numberOfBoards;
    [HideInInspector]public int boardsCompleted;
    bool switchingScene;
    // Start is called before the first frame update
    void Start()
    {
        switchingScene = false;
        boardsCompleted = 0;
        wantedBoards = GameObject.FindGameObjectsWithTag("WantedBoard");
        numberOfBoards = wantedBoards.Length;
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject board in wantedBoards)
        {
            if (board.GetComponent<WantedBoardManager>().levelComplete && !switchingScene)
            {
                switchingScene = true;
                //SwitchScene
                CustomSceneManager.instance.GoToScene("MainMenu");
            }
        }
    }
    
}
