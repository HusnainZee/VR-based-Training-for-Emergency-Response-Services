using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private void Start()
    {
        MetricsManager.instance.SetMetric("Collisions", 0);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
        MetricsManager.instance.AddToMetric("Collisions", 1);
    }
}
