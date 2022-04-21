using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrapDoor : MonoBehaviour
{
    XRIDefaultInputActions inputs;
    [SerializeField] private GameObject exitCanvas;
    [SerializeField] private GameObject challengeCanvas; //only for level 1

    [Tooltip("Distance from Trap Door to Player to Activate")]
    [SerializeField] private float distance;

    [Header("Don't Need for Level 1")]
    [SerializeField] LevelCompletion levelCompletion;
    private GameObject player;
    private float distanceFromPlayer;
    Transform cameraTransform;
    private bool switchScene = true;
    public bool playingOutro = false;

    [SerializeField] private DialogManager dm;
    public bool isLevel1 = false;

    private bool tempHide = false; //using this to hide popup right after you've started challenge. it reappears once you approach the trapdoor again

    private void Awake()
    {
        inputs = new XRIDefaultInputActions();
        inputs.XRIRightHand.A.performed += tgb => SwitchScene();
    }

    void Start()
    {
        inputs.XRIRightHand.A.Enable();

        player = GameObject.FindGameObjectWithTag("Player");
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        if(exitCanvas != null) exitCanvas.SetActive(false);
        if (isLevel1) challengeCanvas.SetActive(false);
    }

    void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (!playingOutro)
        {
            if (distanceFromPlayer < distance)
            {
                if(!tempHide) DoorActive(true);
            }
            else
            {
                DoorActive(false);
                tempHide = false;
            }
        }
        //if (levelCompletion != null)
        //if (levelCompletion.LevelComplete())
        //{
        //    DoorActive(true);
        //}
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    public void DoorActive(bool state)
    {
        if(isLevel1 && dm.clipNum == 5)
        {
            if (isLevel1) challengeCanvas.SetActive(state);
            if (isLevel1) challengeCanvas.transform.LookAt(cameraTransform.position);
        }
        else
        {
            if (isLevel1) challengeCanvas.SetActive(false);

            exitCanvas.SetActive(state);
            exitCanvas.transform.LookAt(cameraTransform.position);
        }
    }
    //Needs something to trigger (Button, Collider)
    public void SwitchScene()
    {
        if (distanceFromPlayer < distance && !tempHide)
        {
            if (isLevel1)
            {
                if (dm.clipNum == 5)
                {
                    dm.clipNum++;

                    // --> THIS IS WHERE START OF CHALLENGE IN LEVEL 1 IS TRIGGERED <--

                    if (isLevel1) challengeCanvas.transform.GetChild(0).gameObject.SetActive(false); //turn off challenge begin popup
                    if (isLevel1) challengeCanvas.transform.GetChild(1).gameObject.SetActive(true); //turn on challenge details popup
                    tempHide = true;
                }
                else
                {
                    CustomSceneManager.instance.GoToScene("MainMenu");
                    inputs.XRIRightHand.A.Disable();
                }
            }
            else
            {
                CustomSceneManager.instance.GoToScene("MainMenu");
                inputs.XRIRightHand.A.Disable();
            }
        }
    }
}
