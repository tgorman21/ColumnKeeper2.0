using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class StorybookManager : MonoBehaviour
{
    [Header("Storybook Settings")]
    [SerializeField] private string dialogFileName;
    [SerializeField] private float waitTime;

    [Header("References")]
    [SerializeField] private ParticleSystem poof;
    [SerializeField] private GameObject leftPage;
    [SerializeField] private GameObject rightPage;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private TargetCounter tc;

    private Animator anim;
    private bool preDialogComplete = false;
    private string[] preDialog;
    private string[] postDialog;

    private int lineNum = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();

        var sr = new StreamReader(Application.dataPath + "/ColumnKeeper/Scripts/Storybook/Dialog/" + dialogFileName);
        var fileContents = sr.ReadToEnd();
        sr.Close();

        string[] PreAndPost = fileContents.Split("#"[0]);

        char[] newLine = { '\n' };
        preDialog = PreAndPost[0].Split(newLine, System.StringSplitOptions.RemoveEmptyEntries);
        postDialog = PreAndPost[1].Split(newLine, System.StringSplitOptions.RemoveEmptyEntries);
    }

    public void StartDialog()
    {
        poof.Play();
        leftPage.SetActive(true);
        rightPage.SetActive(true);

        if (!preDialogComplete)
        {
            StartCoroutine(ProgressDialog(preDialog));
        }
        else 
        {
            StartCoroutine(ProgressDialog(postDialog));
        }
    }

    public void EndDialog()
    {
        poof.Play();
        leftPage.SetActive(false);
        rightPage.SetActive(false);
    }

    private IEnumerator ProgressDialog(string[] dialog)
    {
        string currentLine = dialog[lineNum];
        dialogText.text = currentLine;
        lineNum++;

        yield return new WaitForSeconds(waitTime);

        if(lineNum < dialog.Length)
        {
            StartCoroutine(ProgressDialog(dialog)); //progress to next line
        }
        else
        {
            preDialogComplete = true;
            lineNum = 1; //HOT FIX: I just made this equal to 1 instead of 0 to skip the first entry of the end dialog (due to it being an empty string when read from text file)
            anim.SetTrigger("open/close");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            anim.SetTrigger("open/close");
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
