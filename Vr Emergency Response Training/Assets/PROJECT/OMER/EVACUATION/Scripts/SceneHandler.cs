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
    }

    public void Failed(string reason)
    {
        Title.text = "Failure!";
        Title.color = Color.green;
        HudManager.instance.ClearAllEffects();
        FinishMessage.text = reason;
        TPsys.TeleportPlayerWithRotation(FinishLocation);

    }


    public void Restart()
    {
        SceneManager.LoadScene("Evacuation");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }





}
