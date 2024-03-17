using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyLights : MonoBehaviour
{
    List<Light> lights;
    int lightIndex = 0;


    private void Start()
    {
        lights = new List<Light>();
        foreach (Transform child in transform)
        {
            Light temp = child.GetComponent<Light>();
            lights.Add(temp);
        }
        lightIndex = 0;

        StartCoroutine(FlickLights());
    }

   

    IEnumerator FlickLights()
    {
        while(true)
        {
            foreach (Light light in lights)
            {
                light.gameObject.SetActive(false);
            }
            lights[lightIndex].gameObject.SetActive(true);

            lightIndex = (lightIndex + 1) % lights.Count;

            yield return new WaitForSeconds(0.25f);
        }
    }
}
