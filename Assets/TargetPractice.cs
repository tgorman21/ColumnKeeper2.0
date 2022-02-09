using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetPractice : MonoBehaviour
{
    Rigidbody[] targetPieces;
    [SerializeField]float health;
    [SerializeField] bool test = false;
    [SerializeField] TextMeshProUGUI damageText;
    // Start is called before the first frame update
    void Start()
    {
        damageText.enabled = false;
        targetPieces = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            CollapseTarget(100);
        }
    }

    public void CollapseTarget(float damage)
    {
        test = false;
        health -= damage;
        damageText.enabled = true;
        damageText.SetText(damage.ToString("-##"));
        StartCoroutine(HideText());
        if(health <= 0)
        {
            foreach (Rigidbody piece in targetPieces)
            {
                piece.isKinematic = false;
            }
        }
        
    }
    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2);
        damageText.enabled = false;
    }
}
