using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Stage1Dialog : MonoBehaviour
{
    [Header("XR References")]
    [SerializeField] private XRDirectInteractor directInteractorR;
    [SerializeField] private XRDirectInteractor directInteractorL;

    private DialogManager dm;

    private float t = 10;

    private void OnEnable()
    {
        directInteractorR.selectEntered.AddListener(ObjectAttached);
        directInteractorL.selectEntered.AddListener(ObjectAttached);
    }

    private void OnDisable()
    {
        directInteractorR.selectEntered.RemoveListener(ObjectAttached);
        directInteractorL.selectEntered.RemoveListener(ObjectAttached);
    }

    private void Start()
    {
        dm = GetComponent<DialogManager>();
    }

    private void ObjectAttached(SelectEnterEventArgs arg0)
    {
        if (dm.clipNum == 1)
        {
            if (!arg0.interactable.CompareTag("Bow")) return;
            dm.TriggerInLevelAudio();
        }

        if (dm.clipNum == 3)
        {
            if (!arg0.interactable.CompareTag("Arrow")) return;
            dm.TriggerInLevelAudio();
        }
    }

    private void Update()
    {
        if(dm.clipNum == 2)
        {
            t -= Time.deltaTime;

            if (t > 0) return;
            dm.TriggerInLevelAudio();
        }
    }
}
