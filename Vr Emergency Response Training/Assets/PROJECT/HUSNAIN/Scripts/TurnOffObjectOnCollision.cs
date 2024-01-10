using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffObjectOnCollision : MonoBehaviour
{

    [SerializeField] AudioSource RingTheAlarm;

    [SerializeField] AudioSource UnderstandPassAudio;
    [SerializeField] AudioSource PassMethodAudio;


    [SerializeField] AudioSource AtyourRightSeeObjAudio;
    [SerializeField] AudioSource MoveCloserAndPickExtAudio;

    [SerializeField] AudioSource RemovePinAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("AlarmPointer"))
            {
                this.gameObject.SetActive(false);
                RingTheAlarm.Play();
            }
            else if (this.gameObject.CompareTag("PASSpointer"))
            {
                this.gameObject.SetActive(false);

                UnderstandPassAudio.Stop();
                PassMethodAudio.Play();

            }
            else if (this.gameObject.CompareTag("RecogExtinPointer"))
            {
                this.gameObject.SetActive(false);
                AtyourRightSeeObjAudio.Play();
            }
            else if (this.gameObject.CompareTag("PickExtPointer"))
            {
                this.gameObject.SetActive(false);
                MoveCloserAndPickExtAudio.Play();
            }
            else if (this.gameObject.CompareTag("FireLocationPointer"))
            {
                this.gameObject.SetActive(false);
                RemovePinAudio.Play();
            }
        }
        
    }


}
