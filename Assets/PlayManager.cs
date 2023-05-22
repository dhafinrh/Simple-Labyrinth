using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    [SerializeField] float timeleft;
    [SerializeField] TMP_Text currentTimeText;
    [SerializeField] TMP_Text finaltime;
    [SerializeField] Rigidbody rb;
    // [SerializeField] private UnityEvent onStart;
    private TimeSpan time;
    private float totalTimeSpent;
    private bool timerActive = false;
    private float currentTime;

    private void Awake()
    {
        rb.isKinematic = true;
        StartCoroutine(StartCountdown());
    }

    private void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;

            //Kalau waktu abis
            if (currentTime <= 0)
            {
                StopTimer(); 
                LoseCanvas();

            }
            time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
    }

    IEnumerator StartCountdown()
    {
        int countdown = 3;
        while (countdown > 0)
        {
            currentTimeText.text = countdown.ToString();
            yield return new WaitForSeconds(1);
            countdown--;
        }

        StartTimer();
        currentTime = timeleft * 60;
        rb.isKinematic = false;
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public void WinCanvas()
    {
        rb.isKinematic = true;
        winCanvas.SetActive(true);
        finaltime.text = "You Win!\nTime Left : " + time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void LoseCanvas()
    {
        rb.isKinematic = true;
        winCanvas.SetActive(true);
        finaltime.text = "You Lose!\nTime Left : " + time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
}
