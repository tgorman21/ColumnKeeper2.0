using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetCounter : MonoBehaviour
{
    public int targetsHit = 0;
    [SerializeField] public TextMeshProUGUI targetHitText;
    [SerializeField] private BoxCollider storybookCollider;
    public bool allTargetsHit = false;

    private void Update()
    {
        targetHitText.SetText(targetsHit.ToString("Targets hit: ## / 9"));
        if(targetsHit >= 9)
        {
            allTargetsHit = true;
            storybookCollider.enabled = true;
        } 
    }

    public void TargetHit() => targetsHit++;
}
