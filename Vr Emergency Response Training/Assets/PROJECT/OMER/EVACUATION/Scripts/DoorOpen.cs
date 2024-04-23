using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] GameObject ExplosionEffect;
    [SerializeField] Transform ExplosionPoint;

    [SerializeField] TextMeshProUGUI TemperatureText;
    [SerializeField] Quaternion CloseState = Quaternion.Euler(0, -90, 0);
    [SerializeField] Quaternion OpenState = Quaternion.Euler(0, 0, 0);

    int doorState = 0; // 0 = closed, 1 = open;
    Quaternion GotoState;

    FlammableObject door;

    private void Start()
    {
        door = GetComponent<FlammableObject>();
    }
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
        {
            GotoState = OpenState;
            if(door.Temperature >= 500f)
            {
                Debug.Log("The Fire Goes BOOM!");
                Instantiate(ExplosionEffect, ExplosionPoint.position, Quaternion.identity, null);
            }
        }
    }

    public void TemperatureValueSet()
    {
        float temperature = door.Temperature;
        TemperatureText.text = temperature.ToString();

        float redVal = (temperature / 500f);
        Color newColor = new Color(redVal, 0.5f, 1 - redVal, 1);

        TemperatureText.color = newColor;
    }
}