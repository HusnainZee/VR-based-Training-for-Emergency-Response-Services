using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HintAudioSetup : MonoBehaviour
{
    [SerializeField] List<GameObject> Hints = new List<GameObject>();

    void Start()
    {
        
    }

    public void EnableHint()
    {
        if (PlayerPrefs.GetInt("ObjectOnFire", 0) == 0)
        {
            // CLASS A
            Hints[0].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ObjectOnFire") == 1)
        {
            // CLASS B
            Hints[1].SetActive(true);

        }
        else if (PlayerPrefs.GetInt("ObjectOnFire") == 2)
        {
            // ELECTRICAL
            Hints[2].SetActive(true);
        }
    }
}
