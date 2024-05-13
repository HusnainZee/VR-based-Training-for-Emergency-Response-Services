using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance;
    [SerializeField] TPSystem TPsys;
    [SerializeField] TextMeshProUGUI Title;
    [SerializeField] TextMeshProUGUI FinishMessage;
    [SerializeField] Transform FinishLocation;
    [SerializeField] Transform FinishPanel;
    [SerializeField] Transform PlayerCam;

    private void Awake()
    {
        instance = this;
    }

    public void Finished()
    {

        Title.text = "Successful!";
        Title.color = Color.green;
        HudManager.instance.ClearAllEffects();
        FinishMessage.text = "Congratulations you have successfully finished the evacuation scene!";
        
        TPsys.TeleportPlayerWithRotation(FinishLocation);

        Invoke("SpawnFinishPanel", 0.5f);

    }

    public void Failed(string reason)
    {
        Title.text = "Failure!";
        Title.color = Color.red;
        HudManager.instance.ClearAllEffects();
        FinishMessage.text = reason;
        
        TPsys.TeleportPlayerWithRotation(FinishLocation);

        Invoke("SpawnFinishPanel", 0.5f);

    }


    public void Restart()
    {
        SceneManager.LoadScene("Evacuation");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void SpawnFinishPanel()
    {
        FinishPanel.gameObject.SetActive(true);
        Vector3 panelPos = PlayerCam.position + (PlayerCam.forward * 2);
        panelPos.y = 1f;
        FinishPanel.position = panelPos;

        FinishPanel.LookAt(PlayerCam);
        FinishPanel.Rotate(0f, 180f, 0f);
    }





}
