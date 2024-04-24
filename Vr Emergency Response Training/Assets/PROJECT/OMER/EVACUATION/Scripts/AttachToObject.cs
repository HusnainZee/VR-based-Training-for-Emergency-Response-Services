using UnityEngine;

public class AttachToObject : MonoBehaviour
{
    [System.Flags]
    public enum AxisConstraints
    {
        None = 0,
        X = 1 << 0,
        Y = 1 << 1,
        Z = 1 << 2
    }

    [SerializeField]
    private Transform target;  // The transform to follow

    [SerializeField]
    private Vector3 positionOffset = Vector3.zero;  // Offset to apply to the position

    [SerializeField]
    private bool followRotation = true;  // Whether to follow the target's rotation

    [SerializeField]
    private AxisConstraints rotationConstraints = AxisConstraints.X | AxisConstraints.Y | AxisConstraints.Z;  // Follow all axes by default

    void LateUpdate()
    {
        // Follow position with offset
        transform.position = target.position + positionOffset;

        if (followRotation)
        {
            Vector3 newRotation = transform.eulerAngles;

            if ((rotationConstraints & AxisConstraints.X) == AxisConstraints.X)
            {
                newRotation.x = target.eulerAngles.x;
            }
            if ((rotationConstraints & AxisConstraints.Y) == AxisConstraints.Y)
            {
                newRotation.y = target.eulerAngles.y;
            }
            if ((rotationConstraints & AxisConstraints.Z) == AxisConstraints.Z)
            {
                newRotation.z = target.eulerAngles.z;
            }

            // Apply the new rotation
            transform.eulerAngles = newRotation;
        }
    }
}
