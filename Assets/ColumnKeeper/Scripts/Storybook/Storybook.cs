using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Storybook : MonoBehaviour
{
    [Header("Storybook Settings")]
    [SerializeField] private float waitTime;

    [Header("References")]
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private Transform XRRig;
    [SerializeField] private ContinuousMoveProviderBase playerMovement;

    public static int highestUnlockedLevel = 1;
    private static bool playPostDialog = false;
    private static string[] preDialog;
    private static string[] postDialog;

    private static int levelNum;
    private int lineNum;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
        if (playPostDialog) //when scene starts, check if player is returning from level to trigger post dialog 
        {
            //freeze movement of player
            TogglePlayerMovement(); 

            //move XRRig to be in front of the storybook
            Vector3 pos = new Vector3(3.5f, 0.6f, -0.65f);
            XRRig.position = pos;

            //trigger post dialog animation
            anim.SetTrigger("postdialog");

            //unlock next level if player just completed highest unlocked level
            if(levelNum == highestUnlockedLevel) { highestUnlockedLevel++; }

            lineNum = 1; //HOT FIX: I just made this equal to 1 instead of 0 to skip the first entry of the end dialog (due to it being an empty string when read from text file)
        }
    }

    public void StoryMode() => anim.SetTrigger("storymode");
    public void EndlessMode() => anim.SetTrigger("endless");

    public void Act1() => anim.SetTrigger("act1");
    public void Act2() => anim.SetTrigger("act2");
    public void Act3() => anim.SetTrigger("act3");

    public void Poof() => transform.GetChild(0).GetComponent<ParticleSystem>().Play();

    public void LevelSelect(int _levelNum)
    {
        anim.SetTrigger("predialog");

        string fileName = "Stage_" + _levelNum.ToString();

        
        var file = Resources.Load<TextAsset>("Dialog/" + fileName); //load script from text file into text asset
        var script = file.text;
        
        //
        //OLD APPLICATION.DATA PATH CODE
        //this will need to be updated in the future because Unity themselves recommends avoiding Resources.Load()
        //Switch to Application.streamingAssetsPath in the future
        //
        //var sr = new StreamReader(Application.dataPath + "/ColumnKeeper/Scripts/Storybook/Dialog/" + fileName + ".txt");
        //var fileContents = sr.ReadToEnd();
        //sr.Close();

        string[] PreAndPost = script.Split("#"[0]);

        char[] newLine = { '\n' };
        preDialog = PreAndPost[0].Split(newLine, System.StringSplitOptions.RemoveEmptyEntries);
        postDialog = PreAndPost[1].Split(newLine, System.StringSplitOptions.RemoveEmptyEntries);

        levelNum = _levelNum;
        lineNum = 0;

        TogglePlayerMovement(); //freeze movement of player for remainder of time in scene
    }

    public void PreDialog() => StartCoroutine(ProgressDialog(preDialog));
    public void PostDialog() => StartCoroutine(ProgressDialog(postDialog));

    private IEnumerator ProgressDialog(string[] dialog)
    {
        string currentLine = dialog[lineNum];
        dialogText.text = currentLine;
        lineNum++;

        yield return new WaitForSeconds(waitTime);

        if (lineNum < dialog.Length) { StartCoroutine(ProgressDialog(dialog)); } //progress to next line
        else { EndDialog(); }
    }

    private void EndDialog()
    {
        if (!playPostDialog) //end of predialog
        {
            string sceneName = "Stage_" + levelNum.ToString();
            CustomSceneManager.instance.GoToScene(sceneName);
        }
        else //end of postdialog
        {
            TogglePlayerMovement(); //unfreeze player

            anim.SetTrigger("enddialog"); //trigger animation to reset book back to level select mode
        }
        playPostDialog = !playPostDialog;
    }

    private void TogglePlayerMovement() => playerMovement.enabled = !playerMovement.enabled;
}
