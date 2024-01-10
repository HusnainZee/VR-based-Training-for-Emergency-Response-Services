using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        DontDestroyOnLoad(instance);
    }

}
