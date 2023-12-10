using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachObjectToParent : MonoBehaviour
{
    [SerializeField] Transform parentObj;
    bool isGrabbed = false;
    Vector3 InitialPosition;
    Vector3 scale;

    private void Start()
    {
        InitialPosition = this.transform.localPosition;
        scale = this.transform.localScale;

        XRGrabInteractable grabbable = this.GetComponent<XRGrabInteractable>();
        grabbable.selectEntered.AddListener(ReattachToParent);
    }

    private void Update()
    {
        if (isGrabbed)
        {
            gameObject.transform.SetParent(parentObj);
            gameObject.transform.localPosition = InitialPosition;
            gameObject.transform.localScale = new Vector3(100, 100, 100);
        }
    }

    void ReattachToParent(BaseInteractionEventArgs arg)
    {
        gameObject.transform.SetParent(parentObj);
        gameObject.transform.localPosition = InitialPosition;
        gameObject.transform.localScale = scale;
    }
}

