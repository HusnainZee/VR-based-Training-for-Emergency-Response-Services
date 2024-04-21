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
            player.EnterFumes(fumeIntensity);
    }

    private void OnTriggerExit(Collider other)
    {
        if(player != null)
        {
            player.ExitFumes();
            player = null;
        }
    }

}
