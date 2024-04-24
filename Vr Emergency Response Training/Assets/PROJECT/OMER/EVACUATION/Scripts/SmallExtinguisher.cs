using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallExtinguisher : MonoBehaviour
{

    [SerializeField] GameObject SuppressantPrefab;
    [SerializeField] Transform FirePos;

    bool isFiring = false;
    bool canFire = true;
    float coolDownTime = 0.1f;
    float timer = 0f;
    public void OnActivate()
    {
        isFiring = true;
        canFire = true;
        timer = coolDownTime;
    }

    public void OnActivateExit()
    {
        isFiring = false;
    }

    private void Update()
    {
        if(isFiring && canFire)
        {
            GameObject supressant = Instantiate(SuppressantPrefab, FirePos);
            supressant.GetComponent<ParticleSystem>().Play();
            //Destroy(supressant, 2f);
            canFire = false;
        }

        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            canFire = true;
            timer = coolDownTime;
        }

    }


}
