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
    TargetCounter targetCounter;
    GameObject[] piecesObj;
    public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        targetCounter = GameObject.FindGameObjectWithTag("TargetCounter").GetComponent<TargetCounter>();
        
        hit = false;
        damageText.enabled = false;
        piecesObj = GetComponentsInChildren<GameObject>();
        for(int i =0; i < piecesObj.Length; i++)
        {
            
            if (piecesObj[i].GetComponent<ArrowType>() == null)
            {
                targetPieces = GetComponentsInChildren<Rigidbody>();
            }
                
        }
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
        Debug.Log("Hit " + gameObject.name);
        //GetComponent<Collider>().enabled = false;
        targetCounter.TargetHit();
        if (!hit)
            hit = true;
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
