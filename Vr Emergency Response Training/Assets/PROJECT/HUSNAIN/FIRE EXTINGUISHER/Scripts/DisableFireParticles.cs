using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisableFireParticles : MonoBehaviour
{


    
    [SerializeField] List<GameObject> FireParticles = new List<GameObject>();
    [SerializeField] int countExtinguishedFires = 0;
    [SerializeField] GameObject CertificateImage;

    [SerializeField] GameObject[] LocomotionSystems;

    private void Start()
    {
        countExtinguishedFires = 0;
        PlayerPrefs.SetInt("FireCollisions", 0);
        CertificateImage.SetActive(false);
    }

    private void OnEnable()
    {
        FireSource.FireExtinguished += FireExtinguished;
    }
    private void OnDisable()
    {
        FireSource.FireExtinguished -= FireExtinguished;

    }

    void Update()
    {
        
        if (PlayerPrefs.GetInt("FireCollisions") >= 600)
        {
            if (FireParticles[1].activeSelf == true)
            {
                Debug.LogError("Fire 2 Extinguished");

                FireParticles[1].SetActive(false);
                countExtinguishedFires++;

            }
        }
        else if (PlayerPrefs.GetInt("FireCollisions") >= 300)
        {
            if (FireParticles[0].activeSelf == true)
            {
                Debug.LogError("Fire 1 Extinguished");   
                FireParticles[0].SetActive(false);
                countExtinguishedFires++;

            }
        }

        if (countExtinguishedFires >= FireParticles.Count)
        {
            CertificateImage.SetActive(true);
        }

    }

    void FireExtinguished()
    {
        countExtinguishedFires += 1;
        if(countExtinguishedFires >= 2)
        {

            foreach (GameObject obj in LocomotionSystems)
            {
                obj.SetActive(false);
            }

            CertificateImage.SetActive(true);
        }
    }
}
