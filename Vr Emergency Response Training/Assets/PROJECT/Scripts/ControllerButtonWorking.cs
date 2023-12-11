using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerButtonWorking : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("LeftControllerX"))
        {
            Debug.Log("X pressed on the left controller");
        }
        
        if (Input.GetButton("LeftControllerY"))
        {
            Debug.Log("Y pressed on the left controller");
        }

        if (Input.GetButton("RightControllerB"))
        {
            Debug.Log("B pressed on the right controller");
        }

        if (Input.GetButton("RightControllerA"))
        {
            Debug.Log("A pressed on the right controller");
        }
    }
}
