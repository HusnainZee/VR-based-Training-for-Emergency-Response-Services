using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Injured"))
        {
            Invoke("Finish", 1f);
        }
    }

    void Finish()
    {
        SceneHandler.instance.Finished();
    }
}
