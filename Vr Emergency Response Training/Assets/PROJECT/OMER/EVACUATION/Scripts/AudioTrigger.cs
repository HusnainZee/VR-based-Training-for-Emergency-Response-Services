using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] DialogueSystem DGSystem;
    [SerializeField] int audioIndex;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DGSystem.PlayAudio(audioIndex);
            Invoke("DisableSelf", 3f);
        }
    }

    void DisableSelf()
    {
        this.gameObject.SetActive(false);

    }
}
