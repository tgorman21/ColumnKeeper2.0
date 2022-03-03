using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevelButton : MonoBehaviour
{
    [SerializeField] private int levelNum;

    private void Awake()
    {
        /*
        string levelName = gameObject.name;
        levelName.Remove(0, 5); //remove "Level" from button name
        levelName.Substring(0, levelName.LastIndexOf("_icon")); //remove "_icon" from button name
        int levelNum = int.Parse(levelName); //use string to find level #
        */



        //check if this level is unlocked yet to determine if button is interactable or not
        /*
        if(Storybook.highestUnlockedLevel < levelNum) { GetComponent<Button>().interactable = false; }
        else { GetComponent<Button>().interactable = true; }
        */

        //DEV KEY
        //Turn on all buttons for testing
        GetComponent<Button>().interactable = true;
    }
}
