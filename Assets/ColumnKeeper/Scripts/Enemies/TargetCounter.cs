using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetCounter : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI targetHitText;
    [SerializeField] TrapDoor trapDoor;
    public int targetsHit = 0;
    [SerializeField] private DialogManager dm;
    [SerializeField] private Stage1Dialog stage1Dialog;

    private bool doneChallenge = false;

    private void Update()
    {
        targetHitText.SetText(targetsHit.ToString("## / 9"));
        if (AllTargetsHit())
        {
            dm.TriggerPostLevelAudio();
            stage1Dialog.challengeComplete = true;
        }
    }

    public void TargetHit() => targetsHit++;

    public bool AllTargetsHit() {
        if (targetsHit >= 9 && !doneChallenge) 
        {
            doneChallenge = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
