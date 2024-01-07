using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffObjectOnCollision : MonoBehaviour
{
    [SerializeField] AudioSource UnderstandPassAudio;
    [SerializeField] AudioSource PassMethodAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AlarmPointer"))
        {
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("PASSpointer"))
        {
            UnderstandPassAudio.Stop();
            PassMethodAudio.Play();
            StartCoroutine(TurnOffPassPointer(other.gameObject));
        }
    }

    IEnumerator TurnOffPassPointer(GameObject other)
    {
        yield return new WaitForSeconds(5);
        other.SetActive(false);
    }

}
