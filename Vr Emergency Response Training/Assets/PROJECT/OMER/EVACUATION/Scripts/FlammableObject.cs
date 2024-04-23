using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlammableObject : MonoBehaviour
{

    [SerializeField] GameObject Fire;
    [SerializeField][Range(0,1)] float CombustionRate = 0.1f;
    [SerializeField] float IgnitionPoint = 200f;

    [SerializeField] bool VisualizeTemp;

    float temperature = 30f;

    public float Temperature { get { return temperature; } }

    bool Onfire = false;
    public void AddHeat(float heat)
    {
        if (Onfire)
            return;

        temperature += heat * CombustionRate;

        CheckIgnition();
    }

    private void Update()
    {
        if (VisualizeTemp)
            VisualizeTemperature();
    }

    void CheckIgnition()
    {
        if (temperature >= IgnitionPoint)
        {
            Onfire = true;
            Instantiate(Fire, transform.position, Quaternion.identity);
        }
    }

    void VisualizeTemperature()
    {
        float redVal = (temperature / IgnitionPoint);
        Color newColor = new Color(redVal, 0, 0, 1);
        GetComponent<Renderer>().material.color = newColor;
    }

    


}
