using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FireSource : MonoBehaviour
{
    [SerializeField] Transform ScaleObject;

    List<FlammableObject> flammableList = new List<FlammableObject>();

    [Header("FireProperties")]
    [SerializeField] float intensity = 1;
    [SerializeField] float spreadChance = 0;
    [SerializeField] float heatOutput = 10;
    [SerializeField] private float decreasePerCollision = 1f;
    [SerializeField] LayerMask PlayerLayer;


    [SerializeField] Slider FireBar;


    float maxIntensity = 3f;
    float maxScale = 2f;
    float maxScaleVisual = 1f;
    private ParticleSystem fireParticles;
    
    private float intensityResistance = 6f;
    private float intensityToExtinguish = 0.1f;


    int particleCollisions;
    Player player;

    private void Start()
    {
        player = Player.instance;
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

        UpdateFireMeter();
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

            if(player != null && CanAffectPlayer(other.gameObject.transform))
            {
                player.EnterFire();
            }
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            

            if (player != null && CanAffectPlayer(other.gameObject.transform))
            {
                player.EnterFire();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
            player.ExitFire();
        }
    }
  


    IEnumerator PeriodicAttributeUpdate()
    {
        while(gameObject.activeInHierarchy)
        {
            IncreaseSpreadAndIntensity();
            yield return new WaitForSeconds(Random.Range(10f, 20f));
        }
    }




    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Collisions");
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
            gameObject.GetComponent<AttachFireMeter>().DestroyMeter();
            Destroy(this.gameObject);
        }


        ScaleWithIntensity(-1);
        CalculateHeatOutput();

    }

    bool CanAffectPlayer(Transform player)
    {
        RaycastHit hit;
        Vector3 direction = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out hit, 2 * intensity, PlayerLayer))
        {


            Debug.Log("Raycast got: " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Player"))
                return true;
           
        }

        return false;
           
    }

    void UpdateFireMeter()
    {
        float fillValue = intensity / maxIntensity;
        gameObject.GetComponent<AttachFireMeter>().UpdateMeter(fillValue);
    }

}
