using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateXRInteractionSetup : MonoBehaviour
{
    [SerializeField] GameObject InteractionPrefab;

    private void Awake()
    {
        DontDestroyOnLoad(InteractionPrefab);
    }

}
