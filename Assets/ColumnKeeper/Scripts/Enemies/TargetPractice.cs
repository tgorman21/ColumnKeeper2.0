using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetPractice : MonoBehaviour
{
    [Header("Target Info")]
    [SerializeField] private float health;
    [SerializeField] private bool hit = false;

    [Header("Dev Tools")]
    [SerializeField] private bool collapseTest;

    [Header("References")]
    [SerializeField] private GameObject PopupDamage;
    
    private TargetCounter targetCounter;
    private Rigidbody[] targetPieces;

    private void Start()
    {
        targetCounter = GameObject.FindGameObjectWithTag("TargetCounter").GetComponent<TargetCounter>();
        targetPieces = GetComponentsInChildren<Rigidbody>();
    }

    private void Update()
    {
        if (collapseTest) CollapseTarget(50, transform.position);
    }

    public void CollapseTarget(float damage, Vector3 hitPos)
    {
        //---Dev Tools---
        //Debug.Log("Hit " + gameObject.name);
        //Debug.Log(damage);

        if (!hit) { hit = true; }
        health -= damage;

        GameObject damagePopup = Instantiate(PopupDamage, hitPos, Quaternion.identity);
        damagePopup.transform.GetComponentInChildren<TMP_Text>().SetText(damage.ToString("-##"));

        Vector3 randomForce = (Vector3.up * 10f) + (transform.forward * 2f) + (transform.up * Random.Range(-3f, 3f));
        damagePopup.GetComponent<Rigidbody>().velocity = randomForce;

        if (health > 0) return;

        //target destroyed
        targetCounter.TargetHit();
        foreach (Rigidbody piece in targetPieces) { piece.isKinematic = false; }
    }
}
