using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class IceArrow : MonoBehaviour
{
    [SerializeField] GameObject iceEffect; // Ice Visual Effect

    [SerializeField] GameObject iceCollider; //Ice Collider

    public float DampSpeed; //Damp enemy speed
    public float damageIce; //Ice Arrow Impact Damage
    public bool rise; //Test Function
    [HideInInspector] public float IceSizeX;
    [HideInInspector] public float IceSizeY;
    [HideInInspector] public float IceSizeZ;
    // Start is called before the first frame update
    void Start()
    {
        rise = false;
        PlayerPrefs.SetFloat("IceSizeX", iceEffect.transform.localScale.x);
        PlayerPrefs.SetFloat("IceSizeY", iceEffect.transform.localScale.y);
        PlayerPrefs.SetFloat("IceSizeZ", iceEffect.transform.localScale.z);
        IceSizeX = PlayerPrefs.GetFloat("IceSizeX");
        IceSizeY = PlayerPrefs.GetFloat("IceSizeY");
        IceSizeZ = PlayerPrefs.GetFloat("IceSizeZ");

        iceCollider.transform.localScale = new Vector3(IceSizeX, IceSizeZ, IceSizeY);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Test Function (Mac)
        if (rise)
        {
            IceEffect(damageIce);
        }
    }
    public void IceEffect(float damage)
    {
        //////Turns Ice effect with right rotation
        iceEffect.SetActive(true);
        iceEffect.transform.rotation = Quaternion.identity;
        damageIce = damage;
        IceDamage();
       
    }
    public void IceDamage()
    {

        rise = false;
        Collider col = iceCollider.GetComponentInChildren<Collider>();

        //enables collider
        col.enabled = true;

        //Rises collider
        if (iceCollider.transform.localScale.z <= 2)
        {
            iceCollider.transform.localScale = Vector3.Lerp(iceCollider.transform.localScale, new Vector3(iceCollider.transform.localScale.x, iceCollider.transform.localScale.y, 6), Time.deltaTime * 5);

            //Lowers collider
            StartCoroutine(ColliderEffect());
        }
    }
    IEnumerator ColliderEffect()
    {
        //////Turns everything back to default after 2 seconds
        yield return new WaitForSeconds(2);
        iceCollider.transform.localScale = new Vector3(iceCollider.transform.localScale.x, iceCollider.transform.localScale.y, 0);
        iceEffect.SetActive(false);
        iceCollider.GetComponentInChildren<Collider>().enabled = false;
    }
}
