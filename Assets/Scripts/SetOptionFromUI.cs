using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetOptionFromUI : MonoBehaviour
{
    public Slider volumeSlider;
    public TMP_Dropdown timerDropdown;
    public float timerValue = 30f;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetGlobalVolume);

        // Set the initial timer value from PersistentData
        if (PersistentData.Instance != null)
        {
            timerValue = PersistentData.Instance.TimerValue;
        }
        else
        {
            timerValue = 30f;
        }

        // Set the initial timer value from PlayerPrefs
        timerValue = PlayerPrefs.GetFloat("TimerValue", 30f);

        // Set the Dropdown options
        string[] timerOptions = new string[] { "30 seconds", "45 seconds", "1 minute", "2 minutes"};
        float[] timerValues = new float[] { 30f, 45f, 60f, 120f};

        // Create a list of Dropdown options
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        for (int i = 0; i < timerOptions.Length; i++)
            {
                options.Add(new TMP_Dropdown.OptionData(timerOptions[i]));
            }

        // Set the Dropdown options
        timerDropdown.ClearOptions();
        timerDropdown.AddOptions(options);

        // Set the initial selected option
        for (int i = 0; i < timerValues.Length; i++)
        {
            if (timerValue == timerValues[i])
            {
                timerDropdown.value = i;
                break;
            }
        }
        timerDropdown.onValueChanged.AddListener(UpdateTimerValue);
    }

    public void UpdateTimerValue(int newValue)
    {
        string[] timerOptions = new string[] { "30 seconds","45 Seconds", "1 minute", "2 minutes"};
        int[] timerValues = new int[] { 30, 45, 60, 120};

        timerValue = timerValues[newValue];
        PlayerPrefs.SetFloat("TimerValue", timerValue);

          if (PersistentData.Instance != null)
          {
            PersistentData.Instance.TimerValue = timerValue;
          }
        
    }
    
    public void SetGlobalVolume(float value)
    {
        AudioListener.volume = value;
    }
}
