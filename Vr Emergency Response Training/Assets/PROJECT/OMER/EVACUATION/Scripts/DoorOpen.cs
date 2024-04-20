using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DoorOpen : MonoBehaviour
{
    int doorState = 0; // 0 = closed, 1 = open;
    [SerializeField] Quaternion CloseState = Quaternion.Euler(0, -90, 0);
    [SerializeField] Quaternion OpenState = Quaternion.Euler(0, 0, 0);

    Quaternion GotoState;


    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, GotoState, Time.deltaTime);
    }

    public void ToggleState()
    {
        doorState = (doorState + 1) % 2;

        if (doorState == 0)
            GotoState = CloseState;
        else
            GotoState = OpenState;

    }
}
