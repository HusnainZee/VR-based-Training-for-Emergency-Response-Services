using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuWorking : MonoBehaviour
{
    [SerializeField] GameObject welcomePanel;
    [SerializeField] GameObject controlsPanel;
    [SerializeField] GameObject taskPanel;
    [SerializeField] GameObject objectivePanel;
    [SerializeField] GameObject welcomeInteractableParentPanel;
    [SerializeField] PointerGuidance pointerGuidance;

    private void Start()
    {
        welcomeInteractableParentPanel.SetActive(true);
        welcomePanel.SetActive(true);
        controlsPanel.SetActive(false);
        taskPanel.SetActive(false);
        objectivePanel.SetActive(false);
    }

    public void RestartDemo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowControlsPanel()
    {
        welcomePanel.SetActive(false);
        controlsPanel.SetActive(true);
        taskPanel.SetActive(false);
        objectivePanel.SetActive(false);
    }

    public void ShowObjectivesPanel()
    {
        welcomePanel.SetActive(false);
        controlsPanel.SetActive(false);
        taskPanel.SetActive(false);
        objectivePanel.SetActive(true);
    }

    public void ShowTasksPanel()
    {
        welcomePanel.SetActive(false);
        controlsPanel.SetActive(false);
        taskPanel.SetActive(true);
        objectivePanel.SetActive(false);
    }
    public void HideAllPanels()
    {
        welcomeInteractableParentPanel.SetActive(false);
        pointerGuidance.AlarmPointer();
    }

    public void SceneReloadAndUpdateObj()
    {
        int ObjOnFire = PlayerPrefs.GetInt("ObjectOnFire");
        ObjOnFire++;

        if (ObjOnFire >= 3)
        {
            ObjOnFire = 0;
        }

        PlayerPrefs.SetInt("ObjectOnFire", ObjOnFire);
        SceneManager.LoadScene("Fire Extinguisher");
    }

    public void SceneLoadUnguided()
    {
        SceneManager.LoadScene("Fire Extinguisher Unguided");
    }

}
