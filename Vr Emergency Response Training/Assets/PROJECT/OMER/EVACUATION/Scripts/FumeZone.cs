using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FumeZone : MonoBehaviour
{
    [SerializeField] float fumeIntensity;

    Player player;

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log("Player Entered");
            player.EnterFumes(fumeIntensity);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        player = other.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log("Player Exited");
            player.ExitFumes();

        }
    }

}
