using SojaExiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtinguisherWorking : MonoBehaviour
{

    [SerializeField] ParticleSystem smokeParticle; 

    private void Start()
    {
        XRGrabInteractable grabbale = this.GetComponent<XRGrabInteractable>();
        
        grabbale.activated.AddListener(StartParticles);
        
        grabbale.deactivated.AddListener(StopParticles);
        grabbale.selectExited.AddListener(StopParticles);

    }

    public void StartParticles(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            Debug.Log("EXTRACTED");
            smokeParticle.Play();
        }
        Debug.Log("SMOKE STARTED");

    }

    public void StopParticles(BaseInteractionEventArgs arg)
    {
        Debug.Log("REMOVED");

        smokeParticle.Stop();
    }
}
