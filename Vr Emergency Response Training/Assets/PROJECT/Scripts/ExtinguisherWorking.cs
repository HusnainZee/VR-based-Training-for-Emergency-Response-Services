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
        XRGrabInteractable grabbable = this.GetComponent<XRGrabInteractable>();
        
        grabbable.activated.AddListener(StartParticles);
        grabbable.deactivated.AddListener(StopParticles);

        grabbable.selectExited.AddListener(StopParticles);
    }

    public void StartParticles(BaseInteractionEventArgs arg)
    {
        smokeParticle.Play();
    }

    void StopParticles(BaseInteractionEventArgs arg)
    {
        smokeParticle.Stop();
    }
}
