using System.Collections;
using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class PlayManager : MonoBehaviour
{
    [SerializeField] private GameObject phone;
    [SerializeField] GameObject winCanvas;
    [SerializeField] float timeleft;
    [SerializeField] TMP_Text currentTimeText;
    [SerializeField] TMP_Text finaltime;
    [SerializeField] Rigidbody rb;
    [SerializeField] private UnityEvent onStart;
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
        PhoneFlip();
        int countdown = 3;
        while (countdown > 0)
        {
            currentTimeText.text = countdown.ToString();
            yield return new WaitForSeconds(1);
            countdown--;
        }

        StartTimer();
        onStart.Invoke();
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

    private void PhoneFlip()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(phone.transform.DOLocalMove(new Vector3(0, 0, 1), 1f).SetEase(Ease.OutExpo));
        sequence.Append(phone.transform.DOLocalRotate(new Vector3(180, 0, 0), 1f).SetEase(Ease.OutExpo));
    }

    public void WinCanvas()
    {
        rb.isKinematic = true;
        winCanvas.SetActive(true);
        finaltime.text = "You Win!\nTime Left : \n" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }

    public void LoseCanvas()
    {
        rb.isKinematic = true;
        winCanvas.SetActive(true);
        finaltime.text = "You Lose!\nTime Left : \n" + time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
}
