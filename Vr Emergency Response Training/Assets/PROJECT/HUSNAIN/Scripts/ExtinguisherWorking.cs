using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class ExtinguisherWorking : MonoBehaviour
{
    [SerializeField] GameObject smokeParticlePrefab;
    [SerializeField] Transform instantiatePos;

    [SerializeField] AudioSource SweepAudio;
    [SerializeField] AudioSource AimAudio;

    bool isGrabbed = false;
    bool isInstantiated = false;
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

            if (isInstantiated)
            {
                GameObject smoke = Instantiate(smokeParticlePrefab, instantiatePos);
                smoke.transform.parent = null;
                smoke.GetComponent<ParticleSystem>().Play();
                StartCoroutine(DestroySmokeParticle(smoke));

                isInstantiated = false;
                StartCoroutine(turnOnIstantiatedBool());
            }
        }
    }

    public void Grabbed(BaseInteractionEventArgs arg)
    {
        isGrabbed = true;
        isInstantiated = true;

        if (isFirst)
        {
            SweepAudio.Play();
            isFirst = false;
        }

        AimAudio.Stop();
    }


    IEnumerator turnOnIstantiatedBool()
    {
        yield return new WaitForSeconds(0.1f);
        isInstantiated = true;
    }

    public void NotGrabbed(BaseInteractionEventArgs arg)
    {
        isGrabbed = false;
        hapticOnActivated.SwitchVibrationForever(false);

    }

    IEnumerator DestroySmokeParticle(GameObject smoke)
    {
        yield return new WaitForSeconds(2f);
        GameObject.Destroy(smoke);
    }

}
