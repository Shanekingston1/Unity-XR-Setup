using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Haptics
{
    [Range(0,1)] 
    public float intensity;
    public float duration;
    
    public void TriggerHaptics(BaseInteractionEventArgs eventArgs)
    {
        if(eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractorObject)
        {
            TriggerHaptics(controllerInteractorObject.xrController);
        }
    }
    public void TriggerHaptics(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}
public class HapticsInteractable : MonoBehaviour
{
    public Haptics hapticsOnActivated;
    public Haptics hapticsHoverEntered;
    public Haptics hapticsHoverExited;
    public Haptics hapticsSelectEntered;
    public Haptics hapticsSelectExited;
    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(hapticsOnActivated.TriggerHaptics);

        interactable.hoverEntered.AddListener(hapticsHoverEntered.TriggerHaptics);
        interactable.hoverExited.AddListener(hapticsHoverExited.TriggerHaptics);
        interactable.selectEntered.AddListener(hapticsSelectEntered.TriggerHaptics);
        interactable.selectExited.AddListener(hapticsSelectExited.TriggerHaptics);
    }

}
