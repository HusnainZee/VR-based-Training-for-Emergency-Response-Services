using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomVRInput : MonoBehaviour
{

    public static CustomVRInput instance;

    [SerializeField] InputActionReference RightTrigger = null;
    [SerializeField] InputActionReference LeftTrigger = null;
    [SerializeField] Transform SteeringWheel;

    float throttle = 0f;
    float brake = 0f;
    float steeringInput = 0f;


    private void Awake()
    {
        throttle = brake = steeringInput = 0f;

        instance = this;
    }
    private void Start()
    {
    }


    private void Update()
    {
        throttle = RightTrigger.action.ReadValue<float>();
        brake = LeftTrigger.action.ReadValue<float>();


        float rotationVal = SteeringWheel.localRotation.z;
        //rotationVal = Mathf.Clamp(rotationVal, -0.5f, 0.5f);
        //SteeringWheel.localRotation = Quaternion.Euler(0, 0, rotationVal * 180f);

        steeringInput = SteeringWheel.localRotation.z * 2;
        steeringInput = Mathf.Clamp(steeringInput, -1, 1);

    }

    public Vector3 GetInputs()
    {
        return new Vector3(throttle, brake, steeringInput);
    }

}
