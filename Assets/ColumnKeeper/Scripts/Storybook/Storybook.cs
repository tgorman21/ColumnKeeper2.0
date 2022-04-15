using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Storybook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private Transform XRRig;
    [SerializeField] private ContinuousMoveProviderBase playerMovement;

    public static int highestUnlockedLevel = 1;

    private static int levelNum;
    private int lineNum;

    private string[] dialog;

    private Animator anim;
    private AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        //move XRRig to be in front of the storybook
        Vector3 pos = new Vector3(3.5f, 0.6f, -0.65f);
        XRRig.position = pos;

        //unlock next level if player just completed highest unlocked level
        if(levelNum == highestUnlockedLevel) { highestUnlockedLevel++; }
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

        //load script from text file into text asset
        var file = Resources.Load<TextAsset>("Dialog/" + fileName); 
        var script = file.text;

        //load and play audio clip for selected level
        var audio = Resources.Load<AudioClip>("StorybookAudio/" + fileName);
        audioSource.clip = audio;
        audioSource.Play();
        
        // ===OLD APPLICATION.DATA PATH CODE===
        //this will need to be updated in the future because Unity themselves recommends avoiding Resources.Load()
        //Switch to Application.streamingAssetsPath in the future
        
        //var sr = new StreamReader(Application.dataPath + "/ColumnKeeper/Scripts/Storybook/Dialog/" + fileName + ".txt");
        //var fileContents = sr.ReadToEnd();
        //sr.Close();

        char[] newLine = { '\n' };
        dialog = script.Split(newLine, System.StringSplitOptions.RemoveEmptyEntries);

        levelNum = _levelNum;
        lineNum = 0;
    }

    public void TriggerDialog() => StartCoroutine(ProgressDialog(dialog));

    private IEnumerator ProgressDialog(string[] dialog)
    {
        string[] currentLine = dialog[lineNum].Split(":"[0]);
        string character = currentLine[0];
        string[] scriptAndDuration = currentLine[1].Split("-"[0]);
        string script = scriptAndDuration[0];
        int duration = int.Parse(scriptAndDuration[1]);

        //DisplayCharacter(character, duration);
        dialogText.text = script;
        lineNum++;

        yield return new WaitForSeconds(duration);

        if (lineNum < dialog.Length) { StartCoroutine(ProgressDialog(dialog)); } //progress to next line
        else { EndDialog(); }
    }

    private void EndDialog()
    {
        string sceneName = "Stage_" + levelNum.ToString();
        CustomSceneManager.instance.GoToScene(sceneName);
    }

    private void DisplayCharacter(string character, int duration)
    {
        //Switch statement for each character name that could exist in a text file
        switch (character)
        {
            case "Humphry":

                break;
            case "PrincessMaple":

                break;
            default:
                Debug.Log("!!! Character name read from text file is not a valid character name !!!");
                break;
        }

    }
}
