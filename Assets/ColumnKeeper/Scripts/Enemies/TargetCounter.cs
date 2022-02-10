using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetCounter : MonoBehaviour
{
    public int targetsHit = 0;
    [SerializeField] public TextMeshProUGUI targetHitText;
    public bool allTargetsHit = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        targetHitText.SetText(targetsHit.ToString("Targets hit: ## / 9"));
        if(targetsHit >= 9)
        {
            allTargetsHit = true;
        }
        
    }
    public void TargetHit()
    {
        targetsHit++;
    }
}
