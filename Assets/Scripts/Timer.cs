using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Events")]
    public UnityEvent OnTimerEnd;
    private bool timeEnded= false;
  
    public static Timer instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
      private void Start()
    {
        // Access the timerValue from SetOptionFromUI
        currentTime = SetOptionFromUI.timerValue;
    }

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

        if((hasLimit &&  ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit))))
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

    public void UpdateCurrentTime(float timerValue)
    {
        timerValue = currentTime;
    }

    /*public static void SetTimerLimit(float newLimit)
    {
        if(instance!=null)
        {
            instance.currentTime = SetOptionFromUI.timerValue;
        }
        
    }*/

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0.0");
    }
    
}
