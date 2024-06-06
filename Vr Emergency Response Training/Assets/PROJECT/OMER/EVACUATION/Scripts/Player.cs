using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] TextMeshProUGUI HealthText;
    [SerializeField] TextMeshProUGUI OxygenText;
    [SerializeField] TextMeshProUGUI MaskText;
    [SerializeField] bool Breathe = true;



    
    [SerializeField] float PlayerMaxHealth = 100f;
    bool wearingMask;


    float maxOxygen = 100f;
    float oxygenRemaining;
    float playerHealth;


    bool inFumes = false;
    bool inFire = false;
    float oxygenReductionRate;
    float damageFromFire = 1f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        if (HealthText != null && OxygenText != null)
        {
            playerHealth = PlayerMaxHealth;
            oxygenRemaining = maxOxygen;
        }

        wearingMask = false;
        inFumes = false;
        inFire = false;

        if(Breathe && HudManager.instance != null)
            StartCoroutine(BreatheOxygen());
    }

    private void Update()
    {
        if(HealthText != null && OxygenText != null && MaskText!=null)
        {
            HealthText.text = string.Format("{0}%", playerHealth);
            OxygenText.text = string.Format("{0}%", oxygenRemaining);
            MaskText.text = string.Format("{0}", (wearingMask ? "ON" : "OFF"));
        }
        
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
                    playerHealth-= damageFromFire;
                    PlayerHudPanel.instance.DisplayWarning("You are taking damage from fire!", 2f);
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
                    PlayerHudPanel.instance.DisplayWarning("You are suffocating due to fumes!\nYou need to be wearing a mask!", 2f);
                    HudManager.instance.OxygenEffect(oxygenRemaining / maxOxygen);

                }
                else if (oxygenRemaining <= 0)
                {
                    if (playerHealth > 0)
                    {
                        playerHealth--;
                        HudManager.instance.HealthEffect();
                    }
                }

                if (playerHealth <= 0)
                {

                    SceneHandler.instance.Failed("Suffocated due to fumes!");
                    Debug.Log("Out of Oxygen!");
                }
            }
            else
            {
                HudManager.instance.ClearAllEffects();
            }

            oxygenRemaining = Mathf.Clamp(oxygenRemaining, 0, maxOxygen);
            playerHealth = Mathf.Clamp(playerHealth, 0, PlayerMaxHealth);


            yield return new WaitForSeconds(0.25f);

        }
    }

    

}
