using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrapDoor : MonoBehaviour
{
    XRIDefaultInputActions inputs;
    [SerializeField] GameObject exitCanvas;

    [Tooltip("Distance from Trap Door to Player to Activate")]
    [SerializeField] private float distance;

    [Header("Don't Need for Level 1")]
    [SerializeField] LevelCompletion levelCompletion;
    private GameObject player;
    private float distanceFromPlayer;
    Transform cameraTransform;
    private bool switchScene = true;

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
        if(exitCanvas != null)
        {
            exitCanvas.SetActive(false);
        }
    }

    void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceFromPlayer < distance)
        {
            DoorActive(true);
        }
        else
        {
            DoorActive(false);
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
        exitCanvas.SetActive(state);
        exitCanvas.transform.LookAt(cameraTransform.position);
    }
    //Needs something to trigger (Button, Collider)
    public void SwitchScene()
    {
        if (distanceFromPlayer < distance)
        {
            CustomSceneManager.instance.GoToScene("MainMenu");
            inputs.XRIRightHand.A.Disable();
        }

    }
}
