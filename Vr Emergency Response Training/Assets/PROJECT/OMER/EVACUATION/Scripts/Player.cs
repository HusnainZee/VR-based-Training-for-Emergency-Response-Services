using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI HealthText;
    [SerializeField] TextMeshProUGUI OxygenText;
    [SerializeField] TextMeshProUGUI MaskText;



    [SerializeField] float PlayerMaxHealth = 100f;
    [SerializeField] bool wearingMask;


    float maxOxygen = 100f;
    float oxygenRemaining;
    float playerHealth;


    bool inFumes = false;
    float oxygenReductionRate;

    private void Start()
    {
        playerHealth = PlayerMaxHealth;
        oxygenRemaining = maxOxygen;
        wearingMask = false;
        inFumes = false;

        StartCoroutine(BreatheOxygen());
    }

    private void Update()
    {
        HealthText.text = string.Format("Health: {0}%", playerHealth);
        OxygenText.text = string.Format("Oxygen: {0}%", oxygenRemaining);
        MaskText.text = string.Format("Mask: {0}", (wearingMask ? "ON" : "OFF"));
    }

    public void EnterFumes(float fumeIntensity)
    {
        inFumes = true;
        oxygenReductionRate = fumeIntensity / 2f;
    }

    public void ExitFumes()
    {
        inFumes = false;
    }

    public void SetMask(bool wearState)
    {
        wearingMask = wearState;
       // oxygenRemaining = maxOxygen;
    }

    IEnumerator BreatheOxygen()
    {
        while (true)
        {
            if ((wearingMask || !inFumes) && oxygenRemaining < maxOxygen)
            {
                oxygenRemaining++;
            }
            else if(inFumes && !wearingMask)
            {
                if(oxygenRemaining >= 0)
                    oxygenRemaining -= oxygenReductionRate;

                if (oxygenRemaining <= 0)
                {
                    playerHealth--;
                }

                if (playerHealth <= 0)
                {
                    Debug.Log("Out of Oxygen!");
                }
            }

            yield return new WaitForSeconds(0.25f);

        }
    }


}
