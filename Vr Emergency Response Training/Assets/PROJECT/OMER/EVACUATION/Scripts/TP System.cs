using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TPSystem : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] TeleportationProvider TPController;


    public void TeleportPlayer(Transform teleportTo)
    {

        //Player.GetComponent<>();

        Vector3 worldPos = teleportTo.transform.parent.TransformPoint(teleportTo.position);

        //Vector3 newPos = new Vector3(worldPos.x, worldPos.y + Player.transform.position.y, worldPos.z);
        //Player.transform.position = Player.transform.parent.InverseTransformPoint(worldPos);

        TeleportRequest request = new TeleportRequest();
        request.destinationPosition = worldPos;
        request.destinationRotation = Player.transform.rotation;
        request.requestTime = 0.5f;

        TPController.QueueTeleportRequest(request);
    }
}
