using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AbilityDialController : MonoBehaviour
{
    [Header("Right Controller Interactor")]
    [SerializeField] private XRDirectInteractor directInteractorR;

    [Header("Ability Dial Settings")]
    [SerializeField] private Transform dialCanvas;
    [SerializeField] private GameObject[] arrowPrefabs;

    private XRIDefaultInputActions inputs;

    private bool holdingArrow = false;
    private bool showingDial = false;
    private GameObject heldArrow;

    private void Awake()
    {
        inputs = new XRIDefaultInputActions();
        inputs.XRIRightHand.AbilityDial.performed += tgb => ShowDial();
        inputs.XRIRightHand.AbilityDial.canceled += tgb => HideDial();
    }

    private void ShowDial()
    {
        showingDial = true;
        dialCanvas.GetChild(0).gameObject.SetActive(true); //turn on ability dial
    }

    private void HideDial()
    {
        showingDial = false;
        dialCanvas.GetChild(0).gameObject.SetActive(false); //turn off ability dial
    }

    private void OnEnable()
    {
        inputs.Enable();

        directInteractorR.selectEntered.AddListener(ObjectAttachedR);
        directInteractorR.selectExited.AddListener(ObjectDetachedR);

    }
    private void OnDisable()
    {
        inputs.Disable();

        directInteractorR.selectEntered.RemoveListener(ObjectAttachedR);
        directInteractorR.selectExited.RemoveListener(ObjectDetachedR);
    }

    private void ObjectAttachedR(SelectEnterEventArgs arg0)
    {
        if (!arg0.interactable.CompareTag("Arrow")) return;

        holdingArrow = true;
        heldArrow = arg0.interactable.gameObject;
    }

    private void ObjectDetachedR(SelectExitEventArgs arg0)
    {
        if (!arg0.interactable.CompareTag("Arrow")) return;

        holdingArrow = false;
        heldArrow = null;

        dialCanvas.GetChild(0).gameObject.SetActive(false); //turn off ability dial if it was still on
    }

    private void Update()
    {
        if (!holdingArrow) return;

        if (showingDial) ShowingDial();
    }

    private void ShowingDial()
    {
        
    }
}
