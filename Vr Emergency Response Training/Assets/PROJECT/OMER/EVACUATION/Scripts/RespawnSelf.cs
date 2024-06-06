using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSelf : MonoBehaviour
{
    [SerializeField] Transform respawnPosition;
    [SerializeField] float YOffset;

    bool isGrabbed = false;

    private void Start()
    {
        isGrabbed = false;
        
        //if (respawnPosition.parent != null)
        //    tpPos = respawnPosition.parent.TransformPoint(respawnPosition.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.CompareTag("Ground"))
        {
            if(!isGrabbed)
            {
                PlayerHudPanel.instance.DisplayInformation("You Dropped Your Equipment\nIt has been respawned your toolbelt", 2.5f);
                respawnPosition.gameObject.SetActive(true);
                ItemRespawner.instance.RespawnItem(this.gameObject, respawnPosition.position);

            }
        }
    }

    public void SetGrabState(bool state)
    {
        isGrabbed = state;
    }


}
