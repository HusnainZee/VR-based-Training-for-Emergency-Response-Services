using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSource : MonoBehaviour
{
    //[SerializeField] Transform ProbePoints;

    List<FlammableObject> flammableList = new List<FlammableObject>();
    [SerializeField] float intensity = 1;
    [SerializeField] float spreadChance = 0;
    [SerializeField] float heatOutput = 10;

    float maxScale = 3f;
    private void Start()
    {
        StartCoroutine(PeriodicAttributeUpdate());
        maxScale = Random.Range(2f, 3f);
    }


    private void FixedUpdate()
    {
        foreach (FlammableObject obj in flammableList)
        {
            obj.AddHeat(heatOutput * Time.deltaTime);
        }
    }

    void IncreaseSpreadAndIntensity()
    {
        intensity += (intensity / 2);
        spreadChance += (intensity * heatOutput) / 100f;

        ScaleWithIntensity();
        CalculateHeatOutput();
    }

    void CalculateHeatOutput()
    {
        heatOutput = 10 * intensity * spreadChance;
    }

    void ScaleWithIntensity()
    {
        float currentScale = transform.localScale.x;
        float newScale = currentScale + (intensity / 2);

        if (newScale >= maxScale)
            newScale = maxScale;
        
        transform.localScale = Vector3.one * newScale;
    }


    private void OnTriggerEnter(Collider other)
    {
        FlammableObject flammableObject = other.gameObject.GetComponent<FlammableObject>();
        if(flammableObject != null)
        {
            if(!flammableList.Contains(flammableObject));
                flammableList.Add(flammableObject);
        }
    }


    IEnumerator PeriodicAttributeUpdate()
    {
        while(gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(Random.Range(10f, 20f));
            IncreaseSpreadAndIntensity();
        }
    }
}
