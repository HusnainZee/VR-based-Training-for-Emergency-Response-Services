using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField] Animator handAnimator;

    [SerializeField] InputActionProperty pinchAnimationActions;
    [SerializeField] InputActionProperty gripAnimationActions;
    
    float triggerValue;
    float gripValue;

    void Update()
    {
        triggerValue = pinchAnimationActions.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        gripValue = gripAnimationActions.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);

    }
}
