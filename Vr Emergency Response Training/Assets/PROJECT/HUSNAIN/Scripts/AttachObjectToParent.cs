using SplineMesh;
using System;
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
    [SerializeField] Vector3 InitialPosition;
    [SerializeField] Vector3 scale;
    [SerializeField] Vector3 defaultSplineRot;
    [SerializeField] Vector3 defaultSplinePos;
    [SerializeField] Vector3 AdditionVector;
    [SerializeField] List<float> multiplier = new List<float>();

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

    void GrabbedOff(BaseInteractionEventArgs arg)
    {
        isGrabbed = false;
    }





    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Spline sp;
    //[SerializeField] GameObject RightController;
    //[SerializeField] GameObject AttachPoint;


    //private void Start()
    //{
    //    sp = this.GetComponent<Spline>();
    //    RightController = GameObject.FindGameObjectWithTag("RightController");
    //    XRGrabInteractable grabbable = this.GetComponent<XRGrabInteractable>();
    //    grabbable.selectEntered.AddListener(Grabbed);
    //    grabbable.selectExited.AddListener(NotGrabbed);
    //}

    //void Grabbed(BaseInteractionEventArgs arg)
    //{
    //    //gameObject.transform.SetParent(parentObj);
    //    //gameObject.transform.localPosition = InitialPosition;
    //    //gameObject.transform.localScale = scale;
    //    Debug.Log("Grabbed");
    //    isGrabbed = true;
    //}

    //void NotGrabbed(BaseInteractionEventArgs arg)
    //{
    //    //gameObject.transform.SetParent(parentObj);
    //    //gameObject.transform.localPosition = InitialPosition;
    //    //gameObject.transform.localScale = scale;
    //    Debug.Log("Not Grabbed");
    //    isGrabbed = false;
    //}

    //private void Update()
    //{
    //    //if (isGrabbed == false)
    //    //{
    //    gameObject.transform.SetParent(parentObj);
    //    gameObject.transform.localPosition = InitialPosition;
    //    gameObject.transform.localScale = scale;

    //    if (isGrabbed)
    //    {
    //        if (RightController)
    //        {
    //            sp.nodes[2].Position = new Vector3(RightController.transform.localPosition.x * multiplier[0] + AdditionVector.x, RightController.transform.localPosition.y * multiplier[1] + AdditionVector.y, RightController.transform.localPosition.z * multiplier[2] + AdditionVector.z);
    //            Debug.Log("sp: " + sp.nodes[2].Position);
    //            Debug.Log("hand: " + RightController.transform.localPosition);

    //        }
    //        else
    //        {
    //            Debug.Log("CONTROLLER NO");
    //        }
    //    }
    //    else
    //    {
    //        sp.nodes[2].Position = defaultSplinePos;
    //    }

    //    //}

    //}

}

