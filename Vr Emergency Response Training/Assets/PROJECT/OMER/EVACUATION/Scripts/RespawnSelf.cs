using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSelf : MonoBehaviour
{
    [SerializeField] Transform respawnPosition;
    [SerializeField] float YOffset;

    bool isGrabbed = false;
    Vector3 tpPos;

    private void Start()
    {
        isGrabbed = false;

        tpPos = respawnPosition.position;
        //if (respawnPosition.parent != null)
        //    tpPos = respawnPosition.parent.TransformPoint(respawnPosition.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected");

        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground Detected");
            if(!isGrabbed)
            {

                Debug.Log("Respawn Initiated");
                respawnPosition.gameObject.SetActive(true);
                ItemRespawner.instance.RespawnItem(this.gameObject, tpPos);

            }
        }
    }

    public void SetGrabState(bool state)
    {
        isGrabbed = state;
    }


}
