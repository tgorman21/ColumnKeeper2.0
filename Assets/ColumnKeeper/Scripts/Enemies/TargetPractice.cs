using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetPractice : MonoBehaviour
{
    public bool hit = false;

    [SerializeField] private float health;
    [SerializeField] private bool test = false;
    [SerializeField] private TextMeshProUGUI damageText;

    TargetCounter targetCounter;
    GameObject[] piecesObj;
    private Rigidbody[] targetPieces;

    void Start()
    {
        targetCounter = GameObject.FindGameObjectWithTag("TargetCounter").GetComponent<TargetCounter>();
        targetPieces = GetComponentsInChildren<Rigidbody>();
    }
        
    private void Update()
    {
        if (test)
        {
            CollapseTarget(50);
        }
    }

    public void CollapseTarget(float damage)
    {
        Debug.Log("Hit " + gameObject.name);
        Debug.Log(damage);

        if (!hit) { hit = true; }

        health -= damage;
        damageText.enabled = true;
        damageText.SetText(damage.ToString("-##"));
        StartCoroutine(HideText());
        if(health <= 0)
        {
            targetCounter.TargetHit();
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
