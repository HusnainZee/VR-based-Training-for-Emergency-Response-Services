using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaypoint : MonoBehaviour
{
    PlayerWaypointHandler waypointHandler;

    private void Start()
    {
        waypointHandler = GetComponentInParent<PlayerWaypointHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (waypointHandler)
                waypointHandler.ActivateNext();
            else
                Debug.LogError("Waypoint Handler Not Assigned");
        }
    }

}
