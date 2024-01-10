using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Haptic 
{
    [Range(0, 1)]
    public float intensity;
    public float duration;

    bool foreverVibrate = false;

    BaseInteractionEventArgs args;
    XRBaseController contrlr;

    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if (eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            args = eventArgs;
            contrlr = controllerInteractor.xrController;
            
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        if (intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }

    public void SwitchVibrationForever(bool isTrue)
    {
        if (isTrue)
        {
            TriggerHaptic(contrlr);
        }
    }

    private void Update()
    {
        if (foreverVibrate)
        {

        }
    }
}
