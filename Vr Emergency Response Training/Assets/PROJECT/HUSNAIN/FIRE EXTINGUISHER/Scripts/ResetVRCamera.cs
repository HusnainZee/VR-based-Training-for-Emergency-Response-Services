using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ResetVRCamera : MonoBehaviour
{
    [SerializeField] GameObject XRInteraction;
    [SerializeField] GameObject XROrigin;
    [SerializeField] GameObject CameraOffset;
    [SerializeField] GameObject LocomotionSystem;

    private void Start()
    {
        XRInteraction.transform.position = new Vector3(0, 0, -17.87f);
        
        XROrigin.transform.localPosition = new Vector3(0, 0.125f, 2.93f);
        XROrigin.GetComponent<XROrigin>().CameraYOffset = 1.36144f;

        CameraOffset.transform.localPosition = new Vector3(0, 1.36144f, 0);
        LocomotionSystem.transform.localPosition = new Vector3(0, 0, 0);
    }
}
