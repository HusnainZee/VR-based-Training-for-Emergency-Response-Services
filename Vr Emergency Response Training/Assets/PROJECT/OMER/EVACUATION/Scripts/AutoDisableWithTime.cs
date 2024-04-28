using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisableWithTime : MonoBehaviour
{
    [SerializeField] float TimeToDisable;

    private void OnEnable()
    {
        Invoke("DisableThis", TimeToDisable);
    }

    void DisableThis()
    {
        gameObject.SetActive(false);
    }


}
