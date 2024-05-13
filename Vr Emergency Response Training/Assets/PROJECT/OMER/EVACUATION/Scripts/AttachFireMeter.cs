using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachFireMeter : MonoBehaviour
{
    [SerializeField] GameObject FireMeterPrefab;

    GameObject spawnedMeter;
    Slider fireMeter;
    
    private void Start()
    {

        //Vector3 worldPos = transform.parent.TransformPoint(transform.position);

        spawnedMeter = Instantiate(FireMeterPrefab, transform.position + Vector3.up * 0.75f, Quaternion.identity);
        fireMeter = spawnedMeter.GetComponentInChildren<Slider>();
    }

    public void UpdateMeter(float fillValue)
    {
        fireMeter.value = fillValue;
    }

    public void DestroyMeter()
    {
        Destroy(spawnedMeter);
    }

}
