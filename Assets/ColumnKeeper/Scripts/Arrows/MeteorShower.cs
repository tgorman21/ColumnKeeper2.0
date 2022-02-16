using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class MeteorShower : MonoBehaviour
{
    [SerializeField] GameObject meteorShower;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Shower(float damage, Vector3 pos)
    {

        GameObject shower = Instantiate(meteorShower);
        shower.GetComponent<MeteorDamage>().damage = damage;
        
        StartCoroutine(DestroyVisuals(shower));
        shower.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
    IEnumerator DestroyVisuals(GameObject visualEffect)
    {
        yield return new WaitForSeconds(10);
        Destroy(visualEffect);
    }
    IEnumerator ActivateCollider(GameObject collider)
    {
        yield return new WaitForSeconds(2);
        collider.GetComponent<Collider>().enabled = true;
    }
}
