using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] AudioSource[] Dialogues;


    public void PlayAudio(int index)
    {
        Dialogues[index].Play();
    }
}
