using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] private float countDown; //In Minutes
    [SerializeField] private TextMeshProUGUI countDownText;
    private float minutes;
    private float seconds;
    public bool startCountDown;
    private void Awake()
    {
        countDown *= 60;
    }
    void Start()
    {
        startCountDown = false;
    }

    void Update()
    {
        if(startCountDown)
            countDown -= Time.deltaTime;
        minutes = Mathf.Floor(countDown / 60);
        seconds = countDown % 60;

        countDownText.SetText(minutes.ToString() + ":" + seconds.ToString("##"));

        if(countDown <= 0)
        {
            //Do Something
        }
    }
}
