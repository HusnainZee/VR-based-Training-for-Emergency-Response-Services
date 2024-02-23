
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DontDestroyOnLoad : MonoBehaviour
{
    public List<GameObject> dontDestroyObjects = new List<GameObject>();
    public List<GameObject> AddedtoList = new List<GameObject>();

    private void Awake()
    {
        for(int i = 0; i < dontDestroyObjects.Count; i++)
        {
            if (!AddedtoList.Contains(dontDestroyObjects[i]))
            {
                AddedtoList.Add(dontDestroyObjects[i]);
                DontDestroyOnLoad(dontDestroyObjects[i]);
            }
            else
            {
                //Destroy(added);
            }
        }
        
    }

}