using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandModelController : MonoBehaviour
{
    [SerializeField] private InputActionReference handTriggerReference;
    [SerializeField] private InputActionReference handGripReference;
    [SerializeField] private GameObject handModelPrefab;

    private GameObject currentHandModel;
    private Animator anim;

    private void Start()
    {
        currentHandModel = Instantiate(handModelPrefab, transform);
        anim = currentHandModel.GetComponent<Animator>();
    }
    
    private void Update()
    {
        float triggerValue = handTriggerReference.action.ReadValue<float>();
        float gripValue = handGripReference.action.ReadValue<float>();

        anim.SetFloat("Trigger", triggerValue);
        anim.SetFloat("Grip", gripValue);
    }
}
