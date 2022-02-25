using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private Transform XRRig;

    private void Awake() => XRRig = GameObject.FindGameObjectWithTag("Player").transform;

    private void Update()
    {
        transform.LookAt(XRRig);
        transform.Rotate(new Vector3(0, 90, 0));
        transform.localScale = transform.localScale * 0.98f;
        Destroy(gameObject, 2.5f);
    }
}
