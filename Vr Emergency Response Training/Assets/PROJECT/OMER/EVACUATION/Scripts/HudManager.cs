using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
//using UnityEditor.Rendering.LookDev;

public class HudManager : MonoBehaviour
{
    public static HudManager instance;

    [SerializeField] PostProcessVolume Volume;
    [SerializeField] CanvasGroup FadePanel;
    [SerializeField] float FadeSpeed;


    private Vignette vignette;
    bool healthEffect = false;

    private void Awake()
    {
        instance = this;

        if (Volume.profile.TryGetSettings(out Vignette vig))
        {
            vignette = vig;
        }

        vignette.intensity.value = 0f;
        healthEffect = false;
    }

    public void ExecuteFade()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {

        vignette.color.value = Color.black;
        vignette.intensity.value = 1f;
        FadePanel.alpha = vignette.intensity.value;

        yield return new WaitForSeconds(0.25f);

        while (vignette.intensity.value > 0f)
        {
            vignette.intensity.value -= (FadeSpeed * Time.deltaTime)/10000f;
            FadePanel.alpha = vignette.intensity.value;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void OxygenEffect(float oxygen)
    {
        healthEffect = false;
        vignette.color.value = Color.black;
        vignette.intensity.value = 1 - oxygen;
    }

    public void HealthEffect()
    {
        vignette.intensity.value = 1f;
        if (!healthEffect)
        {
            healthEffect = true;
            StartCoroutine(ExecuteHealthEffect());
        }
    }

    IEnumerator ExecuteHealthEffect()
    {

        float redValInit = 0f;
        while(healthEffect)
        {
            float redVal = redValInit;
            while (redVal <= 1f)
            {
                redVal += (FadeSpeed * Time.deltaTime) / 100f;
                Color vigColor = new Color(redVal, 0, 0, 1f);
                vignette.color.value = vigColor;
                yield return new WaitForSeconds(0.01f);
            }

            redValInit = 0.5f;
            while (redVal >= redValInit)
            {
                redVal -= (FadeSpeed * Time.deltaTime) / 100f;
                Color vigColor = new Color(redVal, 0, 0, 1f);
                vignette.color.value = vigColor;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    public void ClearAllEffects()
    {
        healthEffect = false;
        FadePanel.alpha = 0f;
        vignette.intensity.value = 0f;
    }


    



}
