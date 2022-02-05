using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StorybookManager : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            anim.SetTrigger("open/close");
        }
    }
}
