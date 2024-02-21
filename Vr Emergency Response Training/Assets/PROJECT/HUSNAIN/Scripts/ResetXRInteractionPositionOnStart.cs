using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetXRInteractionPositionOnStart : MonoBehaviour
{
    [SerializeField] Vector3 position;
    [SerializeField] Quaternion rotation;

    [SerializeField] GameObject XRInteraction;

    private void Awake()
    {
        XRInteraction = GameObject.FindGameObjectWithTag("XRI");

        if (XRInteraction)
        {
            Debug.Log("XR FOUND");
            XRInteraction.transform.localPosition = position;
            XRInteraction.transform.localRotation = rotation;
        }
    }
}
