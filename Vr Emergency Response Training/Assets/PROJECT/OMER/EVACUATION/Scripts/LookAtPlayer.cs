using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    Transform player;
    private void Start()
    {
        if(Player.instance != null)
         player = Player.instance.transform;
    }
    private void Update()
    {
        //transform.localPosition = Vector3.zero + Vector3.up * 0.25f;
        //transform.localScale = Vector3.one * 0.01f;

        if(player != null)
        {
            transform.LookAt(player);
            transform.Rotate(0, 180f, 0);
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y, 0));
        }
    }
}
