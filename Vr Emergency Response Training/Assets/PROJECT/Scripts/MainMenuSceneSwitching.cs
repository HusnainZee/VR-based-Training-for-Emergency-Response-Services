using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuSceneSwitching : MonoBehaviour
{
    
    public void OpenFireExtinguisherTraining()
    {
        SceneManager.LoadSceneAsync("Fire Extinguisher", LoadSceneMode.Single);
    }

}
