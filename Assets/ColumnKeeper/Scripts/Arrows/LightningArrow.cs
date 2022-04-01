using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningArrow : MonoBehaviour
{
    [SerializeField] GameObject LightningCloud;
    GameObject cloud;
    public float yPos;
    [HideInInspector] public float lightningSize;

    public void LightningStrike(float damage)
    {
        Vector3 pos = new Vector3(this.transform.position.x, this.transform.position.y + yPos, this.transform.position.z);
        cloud = Instantiate(LightningCloud);
        float lightningSize = LightningCloud.transform.localScale.x;
        PlayerPrefs.SetFloat("LightningSize", lightningSize);
        lightningSize = PlayerPrefs.GetFloat("LightningSize");
        LightningCloud.transform.localScale = new Vector3(PlayerPrefs.GetFloat("LightningSize"), PlayerPrefs.GetFloat("LightningSize"), PlayerPrefs.GetFloat("LightningSize"));
        cloud.gameObject.GetComponentInChildren<LightninDamage>().damage = damage;
        cloud.transform.position = pos;

        StartCoroutine(Strike());
    }
    IEnumerator Strike()
    {
        yield return new WaitForSeconds(10.5f);
        cloud.SetActive(false);
    }
}
