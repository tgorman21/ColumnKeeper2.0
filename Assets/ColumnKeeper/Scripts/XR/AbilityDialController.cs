using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AbilityDialController : MonoBehaviour
{
    [Header("Arrow Selections")]
    [SerializeField] private GameObject[] arrowPrefabs;
    [SerializeField] private bool[] lockedStatus;

    [Header("Dial Settings")]
    [SerializeField] private int numSegments;
    [SerializeField] private float snapRange;

    [Header("XR References")]
    [SerializeField] private CustomInteractionManager interaction;
    [SerializeField] private XRDirectInteractor directInteractorR;
    [SerializeField] private ActionBasedSnapTurnProvider snapTurn;

    [Header("UI References")]
    [SerializeField] private Transform dialCanvas;
    [SerializeField] private Transform selector;

    private XRIDefaultInputActions inputs;

    private bool holdingArrow = false;
    private bool showingDial = false;
    private GameObject heldArrow;

    private int currentSelection = -1;

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
        if (currentSelection >= 0 && currentSelection < arrowPrefabs.Length) SwapArrow(currentSelection); //if currently selecting an unlocked arrow type, swap current arrow with that type
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
        Vector2 dir = inputs.XRIRightHand.DialSelect.ReadValue<Vector2>(); //get joystick value from -1 to 1 on x and y axis

        float rot = Mathf.Atan2(dir.y, dir.x); //convert Vector2 to rotation around origin (in radians)
        rot *= Mathf.Rad2Deg; //convert rotation from radians to degrees
        rot -= 90f; //reduce rotation by 90 so that 0 degrees is at Vector2(0, 1)

        SnapToType(rot);
    }

    private void SnapToType(float _rot)
    {
        int selection = -1; //when not selecting something, selection index is -1
        
        selector.localRotation = Quaternion.Euler(new Vector3(0, 0, _rot)); //set initial selector rotation to rot

        float rot = _rot;
        if (rot > 0) rot -= 360; //make rot range from 0 to -360 in clockwise direction

        float offset = Mathf.Abs(rot) % (360 / numSegments); //offset from a possible selection (between 0 and 44)
        if (offset > 22.5f) offset -= 22.5f; //fix offset so it isn't just measuring distance to closest LOWER selection but also closest HIGHER selection
        if (offset > snapRange) //check if rot is within snap range, if not then return
        {
            currentSelection = -1;
            return; 
        }

        selection = Mathf.RoundToInt(Mathf.Abs(rot) / (360 / numSegments)); //index value of selection from 0 to 7
        if (selection == 8) selection = 0; //fix index value of 8 to instead be 0 (when rot is between 337.5 and 359, should round up to 0 instead of 360)
        if (lockedStatus[selection]) //check if this selection is locked, if so then return
        {
            currentSelection = -1;
            return;
        }

        currentSelection = selection; //set this as current selection
        selector.localRotation = Quaternion.Euler(new Vector3(0, 0, selection * -(360 / numSegments))); //snap to selection

        Debug.Log(currentSelection);
    }

    private void SwapArrow(int index)
    {
        //Debug.Log(index);

        Destroy(heldArrow); //destroy previous arrow
        interaction.ForceDeselect(directInteractorR); //force drop previous arrow (if it still somehow exists)

        GameObject newArrow = Instantiate(arrowPrefabs[index]); //instantiate selected arrow type
        interaction.ForceSelect(directInteractorR, newArrow.GetComponent<Arrow>()); //force grab new arrow
        heldArrow = newArrow; //set new arrow as held arrow

        currentSelection = -1; //reset current selection after new arrow is spawned

        //ADD ARROW COOLDOWN HERE
    }
}
