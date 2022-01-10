using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class IceArrow : MonoBehaviour
{
    [SerializeField] GameObject iceEffect;

    [SerializeField] GameObject iceCollider;

    public bool rise;

    float zPos;

    // Start is called before the first frame update
    void Start()
    {
        rise = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (rise)
        {
            IceEffect();
        }
    }
    public void IceEffect()
    {
        iceEffect.SetActive(true);
        iceEffect.transform.rotation = Quaternion.identity;
        IceDamage();
       
    }
    public void IceDamage()
    {
        rise = false;
        Collider col = iceCollider.GetComponentInChildren<Collider>();
        col.enabled = true;
        //iceCollider.transform.rotation = Quaternion.identity;
        if (iceCollider.transform.localScale.z <= 2)
        {
            iceCollider.transform.localScale = Vector3.Lerp(iceCollider.transform.localScale, new Vector3(iceCollider.transform.localScale.x, iceCollider.transform.localScale.y, 6), Time.deltaTime * 5);
            if (col.gameObject.CompareTag("Enemy"))
            {
                if(col.gameObject.GetComponent<Enemy>() != null)
                {
                    col.gameObject.GetComponent<Enemy>().IceArrow(0.5f);
                }
            }
            StartCoroutine(ColliderEffect());
        }
    }
    IEnumerator ColliderEffect()
    {
        yield return new WaitForSeconds(2);
        iceCollider.transform.localScale = new Vector3(iceCollider.transform.localScale.x, iceCollider.transform.localScale.y, 0);
        iceEffect.SetActive(false);
        iceCollider.GetComponentInChildren<Collider>().enabled = false;
    }
}
