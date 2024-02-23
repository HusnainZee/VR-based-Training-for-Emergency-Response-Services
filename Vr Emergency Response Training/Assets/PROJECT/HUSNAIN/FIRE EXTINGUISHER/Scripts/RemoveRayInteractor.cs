
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RemoveRayInteractor : MonoBehaviour
{
    [SerializeField] XRDirectInteractor m_LeftDirectInteractor;
    [SerializeField] XRRayInteractor m_LeftRayInteractor;

    [SerializeField] XRDirectInteractor m_RightDirectInteractor;
    [SerializeField] XRRayInteractor m_RightRayInteractor;

    private void Start()
    {
        //XRGrabInteractable grabbable = this.GetComponent<XRGrabInteractable>();
        //grabbable.selecthovered.AddListener(ReattachToParent);
    }
    private void Update()
    {
        if (Input.GetButton("RightControllerB"))
        {
            Debug.Log("X pressed on the left controller");

            m_LeftRayInteractor.gameObject.SetActive(!m_LeftRayInteractor.gameObject.activeSelf);
            
            if (m_RightRayInteractor.gameObject.activeSelf)
                m_RightRayInteractor.gameObject.SetActive(false);


        }

        if (Input.GetButton("LeftControllerX"))
        {
            Debug.Log("B pressed on the Right controller");

            m_RightRayInteractor.gameObject.SetActive(!m_RightRayInteractor.gameObject.activeSelf);

            if (m_LeftRayInteractor.gameObject.activeSelf)
                m_LeftRayInteractor.gameObject.SetActive(false);


        }
    }
}
