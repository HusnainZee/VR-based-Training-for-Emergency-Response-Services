using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawner : MonoBehaviour
{
    public static ItemRespawner instance;

    private void Awake()
    {
        instance = this;
    }

    public void RespawnItem(GameObject obj, Vector3 pos, Vector3 rot)
    {
        obj.transform.position = pos;
        obj.transform.rotation = Quaternion.Euler(rot);
    }

    public void RespawnItem(GameObject obj, Vector3 pos)
    {
        obj.transform.position = pos;
    }

}
