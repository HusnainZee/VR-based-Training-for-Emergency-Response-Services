using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHudPanel : MonoBehaviour
{
    public static PlayerHudPanel instance;

    [SerializeField] Image PanelImage;
    [SerializeField] TextMeshProUGUI Message;

    [SerializeField] Color InfoColor;
    [SerializeField] Color WarningColor;

    bool currentlyActive = false;
    Animator anim;
    private void Awake()
    {
        if(!instance)
            instance = this;

        currentlyActive = false;
        anim = GetComponent<Animator>();
    }

    public void DisplayInformation(string text, float duration)
    {
        Message.color = InfoColor;
        DisplayMessage(text, duration); 
    }

    public void DisplayWarning(string text, float duration)
    {
        Message.color = WarningColor;
        DisplayMessage(text, duration);
    }

    void DisplayMessage(string text, float duration)
    {
        if (currentlyActive)
            return;

        currentlyActive = true;
        Message.text = text;

        PanelImage.enabled = true;
        Message.gameObject.SetActive(true);

        anim.Play("PlayerHudAppear");
        Invoke("Disable", duration);
    }


    void Disable()
    {
        PanelImage.enabled = false;
        Message.gameObject.SetActive(false);

        Message.text = "";
        currentlyActive = false;
    }


}
