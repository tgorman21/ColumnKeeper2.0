using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetPractice : MonoBehaviour
{
    XRIDefaultInputActions inputs;
    [Header("Target Info")]
    [SerializeField] private float health;
    [SerializeField] private bool hit = false;
    public bool doneIntro = false;

    [Header("Dev Tools")]
    [SerializeField] private bool collapseTest;

    [Header("References")]
    [SerializeField] private GameObject PopupDamage;
    [SerializeField] private DialogManager dm;

    private TargetCounter targetCounter;
    private Rigidbody[] targetPieces;
    private CountDown countDown;
    private void Awake()
    {
        inputs = new XRIDefaultInputActions();
        
    }
    private void Start()
    {
        countDown = GameObject.FindGameObjectWithTag("TargetCounter").GetComponent<CountDown>();
        targetCounter = GameObject.FindGameObjectWithTag("TargetCounter").GetComponent<TargetCounter>();
        targetPieces = GetComponentsInChildren<Rigidbody>();
    }

    private void Update()
    {
        if (collapseTest) CollapseTarget(50, transform.position);

        if(dm.clipNum == 6)
        {
            doneIntro = true;
        }
    }

    public void CollapseTarget(float damage, Vector3 hitPos)
    {
        //---Dev Tools---
        //Debug.Log("Hit " + gameObject.name);
        //Debug.Log(damage);

        if (!hit) { hit = true; }
        health -= damage;

        if (!doneIntro)
        {
            health += damage;
            if (dm.clipNum == 4)
            {
                dm.TriggerInLevelAudio();
            }
        }

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
