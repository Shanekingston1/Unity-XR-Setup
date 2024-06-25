using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Oculus.Interaction.Input;
using UnityEngine;

public class HapticFeedback : MonoBehaviour
{
    [Range(0,1)]
    public float amplitude;
    [Range(0,1)]
    public float frequency;
    [Range(0,2.5f)]
    public float duaration;
    public GrabInteractable grabInteractable;
    
    // Start is called before the first frame update
    void Start()
    {
        grabInteractable.WhenSelectingInteractorAdded.Action += WhenSelectingInteractorAdded_Action;
    }

    private void WhenSelectingInteractorAdded_Action(GrabInteractor obj)
    {
        ControllerRef controllerRef = obj.GetComponent<ControllerRef>();

        if (controllerRef)
        {
            if(controllerRef.Handedness== Handedness.Right)
                TriggerHaptics(OVRInput.Controller.RTouch);
            else
                TriggerHaptics(OVRInput.Controller.LTouch);
        }           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerHaptics(OVRInput.Controller controller)
    {
        StartCoroutine(TriggerHapticsRoutine(controller)); 
    }

    public IEnumerator TriggerHapticsRoutine(OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(amplitude, frequency,controller);
        yield return new WaitForSeconds(duaration);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
