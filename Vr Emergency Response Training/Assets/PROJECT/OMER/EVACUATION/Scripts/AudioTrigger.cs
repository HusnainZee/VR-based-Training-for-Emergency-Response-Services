using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] DialogueSystem DGSystem;
    [SerializeField] int audioIndex;

    bool playedOnce = false;

    private void Start()
    {
        playedOnce = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !playedOnce)
        {
            playedOnce = true;
            DGSystem.PlayAudio(audioIndex);
            Invoke("DisableSelf", 5f);
        }
    }

    void DisableSelf()
    {
        this.gameObject.SetActive(false);

    }
}
