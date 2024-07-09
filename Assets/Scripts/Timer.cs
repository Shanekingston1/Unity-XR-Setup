using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime = 30f;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Events")]
    public UnityEvent OnTimerEnd;
    private bool timeEnded= false;
    
    // Update is called once per frame
    void Update()
    {
        if(countDown == true)
        {
            currentTime -= Time.deltaTime;
            SetTimerText();
        }
        else if(countDown == false)
        {
            currentTime += Time.deltaTime;
            SetTimerText();
        }

        if(hasLimit &&  ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }

        if(currentTime == timerLimit)
        {
            timeEnded = true;
            OnTimerEnd.Invoke();
            
        } 
    } 

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }

    internal void SetTime(float timerValue)
    {
        throw new NotImplementedException();
    }

    public static implicit operator Timer(float v)
    {
        throw new NotImplementedException();
    }
}
