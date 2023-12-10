using SojaExiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtinguisherWorking : MonoBehaviour
{
    private void Start()
    {
        XRGrabInteractable grabbale = this.GetComponent<XRGrabInteractable>();
        grabbale.activated.AddListener(StartParticles);
    }

    public void StartParticles(ActivateEventArgs arg)
    {
            
    }

}
