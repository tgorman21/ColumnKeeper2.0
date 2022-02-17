using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetCounter : MonoBehaviour
{
    [SerializeField] private BoxCollider storybookCollider;
    [SerializeField] public TextMeshProUGUI targetHitText;
    public int targetsHit = 0;

    private void Update()
    {
        targetHitText.SetText(targetsHit.ToString("Targets hit: ## / 9"));

        if(targetsHit >= 9)
        {
            storybookCollider.enabled = true;
        } 
    }

    public void TargetHit() => targetsHit++;
}
