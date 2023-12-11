using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class LadyModelInteraction : MonoBehaviour
{

    [SerializeField] GameObject canvasPanel;
    [SerializeField] GameObject ladyModel;


    public void LeaveHer()
    {
        canvasPanel.SetActive(false);
    }

    public void Evacuate()
    {
        ladyModel.SetActive(false);
    }
}
