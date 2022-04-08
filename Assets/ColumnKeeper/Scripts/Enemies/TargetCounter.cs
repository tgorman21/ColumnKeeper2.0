using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetCounter : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI targetHitText;
    [SerializeField] TrapDoor trapDoor;
    public int targetsHit = 0;

    private bool switchingScene = false;

    private void Update()
    {
        targetHitText.SetText(targetsHit.ToString("## / 9"));
        if (AllTargetsHit())
        {
            CustomSceneManager.instance.GoToScene("MainMenu");

        }
    }

    public void TargetHit() => targetsHit++;

    public bool AllTargetsHit() {
        if (targetsHit >= 9 && !switchingScene) 
        {
            switchingScene = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
