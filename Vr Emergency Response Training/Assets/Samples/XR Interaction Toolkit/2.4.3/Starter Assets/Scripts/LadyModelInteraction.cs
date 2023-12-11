using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class LadyModelInteraction : MonoBehaviour
{

    [SerializeField] GameObject canvasPanel;

    private void Start()
    {
        XRSimpleInteractable interactable  = this.GetComponent<XRSimpleInteractable>();

        interactable.hoverEntered.AddListener(ShowPanel);
        interactable.hoverExited.AddListener(HidePanel);

        //interactable.deactivated.AddListener(StopParticles);

        //interactable.selectExited.AddListener(StopParticles);
    }

    void ShowPanel(BaseInteractionEventArgs arg)
    {
        canvasPanel.SetActive(true);
    }

    void HidePanel(BaseInteractionEventArgs arg)
    {
        canvasPanel.SetActive(false);
    }
}
