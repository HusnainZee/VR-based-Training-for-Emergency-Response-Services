using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnExtinguisherOnDrop : MonoBehaviour
{
    
    public void ResetExtinguisherPos()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);
        gameObject.transform.localPosition = new Vector3(-0.0191865f, 0.156f, -0.05f);
        gameObject.transform.localRotation = Quaternion.Euler(0, -90f, 0);
    }

}
