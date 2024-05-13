using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishHandler : MonoBehaviour
{
    [SerializeField] GameObject UnconciousMan;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Injured"))
        {
            Invoke("Finish", 2f);
        }
    }

    void Finish()
    {
        HudManager.instance.ExecuteFade();
        UnconciousMan.SetActive(false);
        SceneHandler.instance.Finished();
    }
}
