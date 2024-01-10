using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFireParticles : MonoBehaviour
{
    [SerializeField] List<GameObject> FireParticles = new List<GameObject>();
    bool completeFireExtinguished = false;
    int countExtinguishedFires = 0;

    [SerializeField] GameObject CertificateImage;

    private void Start()
    {
        PlayerPrefs.SetInt("FireCollisions", 0);
        CertificateImage.SetActive(false);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("FireCollisions") >= 600)
        {
            if (FireParticles[5].activeSelf == true)
            {
                FireParticles[5].SetActive(false);
                countExtinguishedFires++;
            }
        }
        else if (PlayerPrefs.GetInt("FireCollisions") >= 500)
        {
            if (FireParticles[4].activeSelf == true)
            {
                FireParticles[4].SetActive(false);
                countExtinguishedFires++;

            }
        }
        else if (PlayerPrefs.GetInt("FireCollisions") >= 400)
        {
            if (FireParticles[3].activeSelf == true)
            {
                FireParticles[3].SetActive(false);
                countExtinguishedFires++;

            }
        }
        else if (PlayerPrefs.GetInt("FireCollisions") >= 300)
        {
            if (FireParticles[2].activeSelf == true)
            {
                FireParticles[2].SetActive(false);
                countExtinguishedFires++;

            }
        }
        else if (PlayerPrefs.GetInt("FireCollisions") >= 200)
        {
            if (FireParticles[1].activeSelf == true)
            {
                Debug.LogError("Fire 2 Extinguished");

                FireParticles[1].SetActive(false);
                countExtinguishedFires++;

            }
        }
        else if (PlayerPrefs.GetInt("FireCollisions") >= 100)
        {
            if (FireParticles[0].activeSelf == true)
            {
                Debug.LogError("Fire 1 Extinguished");   
                FireParticles[0].SetActive(false);
                countExtinguishedFires++;

            }
        }

        if (countExtinguishedFires >= 6)
        {
            completeFireExtinguished = true;
            CertificateImage.SetActive(true);
        }

    }
}
