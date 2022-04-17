using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] private float countDown;
    public bool startCountDown;

    void Start()
    {
        startCountDown = false;
    }

    void Update()
    {
        if(startCountDown)
            countDown -= Time.deltaTime;

        if(countDown <= 0)
        {
            //Do Something
        }
    }
}
