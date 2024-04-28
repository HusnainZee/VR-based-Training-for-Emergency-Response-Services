using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireSource : MonoBehaviour
{
    [SerializeField] Transform ScaleObject;

    List<FlammableObject> flammableList = new List<FlammableObject>();
    [SerializeField] float intensity = 1;
    [SerializeField] float spreadChance = 0;
    [SerializeField] float heatOutput = 10;


    float maxIntensity = 3f;
    float maxScale = 2f;
    float maxScaleVisual = 1f;
    private ParticleSystem fireParticles;
    private float decreasePerCollision = 1f;
    private float intensityResistance = 10f;
    private float intensityToExtinguish = 0.1f;


    int particleCollisions;

    private void Start()
    {

        particleCollisions = 0;
        fireParticles = GetComponent<ParticleSystem>();
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

        intensity = Mathf.Clamp(intensity, 0, maxIntensity);

        ScaleWithIntensity(1);
        CalculateHeatOutput();
    }

    void CalculateHeatOutput()
    {
        heatOutput = 10 * intensity * spreadChance;
    }

    void ScaleWithIntensity(int scaleDirection)
    {

        float scaleFactor = intensity / maxIntensity;
        float newScale = maxScale * scaleFactor;
        float newScaleVisual = maxScaleVisual * scaleFactor;

        newScale = Mathf.Clamp(newScale, 1f, maxScale);
        newScaleVisual = Mathf.Clamp(newScaleVisual, 0.1f, maxScaleVisual);
        
        transform.localScale = Vector3.one * newScale;
        ScaleObject.localScale = Vector3.one * newScaleVisual;
    }


    private void OnTriggerEnter(Collider other)
    {
        FlammableObject flammableObject = other.gameObject.GetComponent<FlammableObject>();
        if(flammableObject != null)
        {
            if(!flammableList.Contains(flammableObject));
                flammableList.Add(flammableObject);
        }

        if(other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
            Player player = other.gameObject.GetComponentInChildren<Player>();
            player.EnterFire();
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
            Player player = other.gameObject.GetComponentInChildren<Player>();
            player.ExitFire();
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




    private void OnParticleCollision(GameObject other)
    {

        if(other.CompareTag("ExtParticles"))
        {
            ExtinguishFireLogic();
        }
    }

    void ExtinguishFireLogic()
    {

        particleCollisions++;
        intensity -= Time.deltaTime * (decreasePerCollision / (intensityResistance * intensity));
        Debug.Log("Intensity " + intensity);
        if (intensity <= intensityToExtinguish)
        {
            Debug.Log("Destroying Fire Source" + gameObject.name);
            Destroy(this.gameObject);
        }


        ScaleWithIntensity(-1);
        CalculateHeatOutput();


    }
}
