using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorInteractable : XRBaseInteractable
{
    [SerializeField] private Transform doorTransform;

    public UnityEvent<float> OnDoorRotated;

    private float currentAngle = 0.0f;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        currentAngle = FindDoorAngle();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        currentAngle = FindDoorAngle();
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (isSelected)
                RotateDoor();
        }
    }

    private void RotateDoor()
    {
        // Convert that direction to an angle, then rotation
        float totalAngle = FindDoorAngle();

        // Apply difference in angle to wheel
        float angleDifference = currentAngle - totalAngle;
        doorTransform.Rotate(transform.up, angleDifference, Space.World);

        // Store angle for next process
        currentAngle = totalAngle;
        OnDoorRotated?.Invoke(angleDifference);
    }

    private float FindDoorAngle()
    {
        float totalAngle = 0;

        // Combine directions of current interactors
        foreach (IXRSelectInteractor interactor in interactorsSelecting)
        {
            Vector2 direction = FindLocalPoint(interactor.transform.position);
            totalAngle += ConvertToAngle(direction) * FindRotationSensitivity();
        }

        return totalAngle;
    }

    private Vector2 FindLocalPoint(Vector3 position)
    {
        // Convert the hand positions to local, so we can find the angle easier
        Vector3 interactorPos = transform.InverseTransformPoint(position);

        return new Vector2(interactorPos.x, interactorPos.z).normalized;
    }

    private float ConvertToAngle(Vector2 direction)
    {
        // Use a consistent up direction to find the angle
        return Vector2.SignedAngle(Vector2.up, direction);
    }

    private float FindRotationSensitivity()
    {
        // Use a smaller rotation sensitivity with two hands
        return 1.0f / interactorsSelecting.Count;
    }
}