using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticVibrationController : MonoBehaviour
{
    bool isGrabbed = false;
    bool isFirst = true;

    public Haptic hapticOnActivated;
    XRGrabInteractable grabbable;



    private void Start()
    {
        grabbable = this.GetComponent<XRGrabInteractable>();

        grabbable.activated.AddListener(Grabbed);
        grabbable.activated.AddListener(hapticOnActivated.TriggerHaptic);

        grabbable.deactivated.AddListener(NotGrabbed);

        grabbable.selectExited.AddListener(NotGrabbed);
    }

    private void Update()
    {
        if (isGrabbed)
        {
            hapticOnActivated.SwitchVibrationForever(true);
        }
    }

    public void Grabbed(BaseInteractionEventArgs arg)
    {
        isGrabbed = true;
    }

    public void NotGrabbed(BaseInteractionEventArgs arg)
    {
        isGrabbed = false;
        hapticOnActivated.SwitchVibrationForever(false);

    }

}
