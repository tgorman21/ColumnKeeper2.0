using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetCounter : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI targetHitText;

    public int targetsHit = 0;

    private bool switchingScene = false;

    private void Update()
    {
        targetHitText.SetText(targetsHit.ToString("## / 9"));

        if(targetsHit >= 9 && !switchingScene)
        {
            //This is where end of level occurs
            //For now, just triggering a screen fade into the main menu
            switchingScene = true;
            CustomSceneManager.instance.GoToScene("MainMenu");
        }
    }

    public void TargetHit() => targetsHit++;
}
