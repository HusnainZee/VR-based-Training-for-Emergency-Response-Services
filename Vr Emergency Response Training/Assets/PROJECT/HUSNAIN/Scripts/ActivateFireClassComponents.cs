using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFireClassComponents : MonoBehaviour
{

    [SerializeField] List<GameObject> ObjectsOnFire = new List<GameObject>();
    //[SerializeField] List<GameObject> FireExtinguisherTypes = new List<GameObject>();
    [SerializeField] List<GameObject> FireExtinguisherLabels = new List<GameObject>();


    void Start()
    {
        if (PlayerPrefs.GetInt("ObjectOnFire", 0) == 0)
        {
            // CLASS A
            ObjectsOnFire[0].SetActive(true);
            FireExtinguisherLabels[0].SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ObjectOnFire") == 1)
        {
            // CLASS B
            ObjectsOnFire[1].SetActive(true);
            FireExtinguisherLabels[1].SetActive(true);

        }
        else if (PlayerPrefs.GetInt("ObjectOnFire") == 2)
        {
            // ELECTRICAL
            ObjectsOnFire[2].SetActive(true);
            FireExtinguisherLabels[2].SetActive(true);
        }
    }

    
}
