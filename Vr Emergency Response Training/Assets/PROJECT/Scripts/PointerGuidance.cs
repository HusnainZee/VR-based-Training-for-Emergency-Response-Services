using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerGuidance : MonoBehaviour
{

    [SerializeField] GameObject alarmPointer;
    [SerializeField] GameObject alarmInstructionPanel;

    [SerializeField] GameObject PassPointer;
    [SerializeField] GameObject PASSinstructionPanel;

    private void Start()
    {
        alarmPointer.SetActive(false);
        alarmInstructionPanel.SetActive(false);

        PassPointer.SetActive(false);
        PASSinstructionPanel.SetActive(false);
    }


    public void AlarmPointer()
    {
        alarmPointer.SetActive(true);
        alarmInstructionPanel.SetActive(true);

    }
}
