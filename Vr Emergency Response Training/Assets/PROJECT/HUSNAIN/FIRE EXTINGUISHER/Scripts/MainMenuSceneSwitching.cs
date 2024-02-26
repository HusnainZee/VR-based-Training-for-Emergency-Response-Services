using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuSceneSwitching : MonoBehaviour
{
    public void SceneLoadUnGuided()
    {
        SceneManager.LoadScene("Fire Extinguisher Unguided");
    }

    public void SceneLoadClassA()
    {
        PlayerPrefs.SetInt("ObjectOnFire", 0);
        SceneManager.LoadScene("Fire Extinguisher");
    }
    public void SceneLoadClassB()
    {
        PlayerPrefs.SetInt("ObjectOnFire", 1);
        SceneManager.LoadScene("Fire Extinguisher");
    }

    public void SceneLoadClassElectrical()
    {
        PlayerPrefs.SetInt("ObjectOnFire", 2);
        SceneManager.LoadScene("Fire Extinguisher");
    }

    public void SceneLoadFireWaterTruckPipe()
    {
        SceneManager.LoadScene("Firetruck Water Hose");
    }
}
