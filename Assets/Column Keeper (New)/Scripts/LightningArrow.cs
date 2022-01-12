using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningArrow : MonoBehaviour
{
    [SerializeField] GameObject LightningCloud;
    GameObject cloud;
    public float yPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightningStrike(float damage)
    {
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + yPos, this.transform.position.z);
        cloud = Instantiate(LightningCloud);
        cloud.gameObject.GetComponentInChildren<LightninDamage>().damage = damage;
        cloud.transform.position = pos;

        StartCoroutine(Strike());
    }
    IEnumerator Strike()
    {
        yield return new WaitForSeconds(1.25f);
        cloud.SetActive(false);
    }
}
