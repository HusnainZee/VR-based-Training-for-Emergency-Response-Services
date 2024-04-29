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
    bool inFire = false;
    float oxygenReductionRate;

    private void Start()
    {
        playerHealth = PlayerMaxHealth;
        oxygenRemaining = maxOxygen;
        wearingMask = false;
        inFumes = false;
        inFire = false;


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

    public void EnterFire()
    {
        Debug.Log("Enter Fire");
        inFire = true;
    }

    public void ExitFire()
    {
        Debug.Log("Exit Fire");
        inFire = false;
        HudManager.instance.ClearAllEffects();
    }

    public void ExitFumes()
    {
        Debug.Log("Exited Fumes");
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

            if(inFire)
            {
                if (playerHealth > 0)
                {
                    playerHealth-=5;
                    HudManager.instance.HealthEffect();
                    if (playerHealth <= 0)
                        SceneHandler.instance.Failed("Died due to being in fire!");
                }
            }
            else if ((wearingMask || !inFumes) && oxygenRemaining < maxOxygen)
            {
                oxygenRemaining+=10;
                HudManager.instance.OxygenEffect(oxygenRemaining / maxOxygen);
            }
            else if(inFumes && !wearingMask)
            {
                if(oxygenRemaining > 0)
                {
                    oxygenRemaining -= oxygenReductionRate;
                    HudManager.instance.OxygenEffect(oxygenRemaining / maxOxygen);

                    if (oxygenRemaining <= 0f)
                        HudManager.instance.HealthEffect();
                }
                else if (oxygenRemaining <= 0)
                {
                    if(playerHealth > 0)
                    {
                        playerHealth--;
                    }
                }

                if (playerHealth <= 0)
                {

                    SceneHandler.instance.Failed("Suffocated due to fumes!");
                    Debug.Log("Out of Oxygen!");
                }
            }

            oxygenRemaining = Mathf.Clamp(oxygenRemaining, 0, maxOxygen);
            playerHealth = Mathf.Clamp(playerHealth, 0, PlayerMaxHealth);


            yield return new WaitForSeconds(0.25f);

        }
    }

    

}
