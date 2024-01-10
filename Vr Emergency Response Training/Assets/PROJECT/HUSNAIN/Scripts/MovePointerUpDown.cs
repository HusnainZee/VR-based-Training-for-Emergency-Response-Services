using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointerUpDown : MonoBehaviour
{
    [SerializeField] Transform Object;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float speed = 2.0f;

    private void Update()
    {
        MoveObjectBetweenPoints();
    }

    private void MoveObjectBetweenPoints()
    {
        float step = speed * Time.deltaTime;

        // Move towards point B
        Object.transform.position = Vector3.MoveTowards(Object.transform.position, pointB.position, step);

        // Check if the object has reached point B
        if (Vector3.Distance(Object.transform.position, pointB.position) < 0.001f)
        {
            // Swap points A and B
            Transform temp = pointA;
            pointA = pointB;
            pointB = temp;
        }
    }
}
