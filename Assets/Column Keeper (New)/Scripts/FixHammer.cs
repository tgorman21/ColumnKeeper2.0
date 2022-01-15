using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixHammer : MonoBehaviour
{
    Rigidbody rb;
    public float ct = 0;
    //public GameObject swingText;
    //public AudioSource hammerHit;
    [SerializeField] private float healAmount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity.magnitude);

        ct += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tower") && rb.velocity.magnitude >= 7 && ct > 3)
        {
            //hammerHit.Play();
            other.GetComponent<TowerHealth>().HealTower(healAmount);
            Debug.Log("Tower Repaired");
            ct = 0;
        }
        if (rb.velocity.magnitude <= 7 && rb.velocity.magnitude >= 1 && ct > 3)
        {
            //swingText.SetActive(true);
        }
        else
        {
            //swingText.SetActive(false);
        }
    }
}
