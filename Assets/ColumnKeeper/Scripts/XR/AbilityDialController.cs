using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AbilityDialController : MonoBehaviour
{
    [Header("Arrow Selections")]
    [SerializeField] private GameObject[] arrowPrefabs;

    [Header("XR References")]
    [SerializeField] private XRDirectInteractor directInteractorR;
    [SerializeField] private ActionBasedSnapTurnProvider snapTurn;

    [Header("UI References")]
    [SerializeField] private Transform dialCanvas;
    [SerializeField] private Transform selector;

    private XRIDefaultInputActions inputs;

    private bool holdingArrow = false;
    private bool showingDial = false;
    private GameObject heldArrow;

    private int currentSelection = 0;

    private void Awake()
    {
        inputs = new XRIDefaultInputActions();
        inputs.XRIRightHand.AbilityDial.performed += tgb => ShowDial();
        inputs.XRIRightHand.AbilityDial.canceled += tgb => HideDial();
    }

    private void ShowDial()
    {
        if (!holdingArrow) return; //only show dial if arrow is held

        showingDial = true;
        dialCanvas.GetChild(0).gameObject.SetActive(true); //turn on ability dial

        snapTurn.enabled = false; //disable snap turn while using dial selection
    }

    private void HideDial()
    {
        showingDial = false;
        dialCanvas.GetChild(0).gameObject.SetActive(false); //turn off ability dial

        snapTurn.enabled = true; //enable snap turn while not using dial selection
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

        HideDial(); //hide ability dial if it was still on
    }

    private void Update()
    {
        if (!holdingArrow) return;

        if (showingDial) ShowingDial();
    }

    private void ShowingDial()
    {
        Vector2 dir = inputs.XRIRightHand.Turn.ReadValue<Vector2>(); //get joystick value from -1 to 1 on x and y axis
        float rot = Mathf.Atan2(dir.y, dir.x); //convert Vector2 to rotation around origin (in radians)
        rot *= Mathf.Rad2Deg; //convert rotation from radians to degrees
        rot -= 90f; //reduce rotation by 90 so that 0 degrees is at Vector2(0, 1)

        selector.localRotation = Quaternion.Euler(new Vector3(0, 0, rot));
    }
}
