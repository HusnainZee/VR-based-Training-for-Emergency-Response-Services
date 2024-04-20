using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TPSystem : MonoBehaviour
{

    [SerializeField] GameObject Player;
    public void TeleportPlayer(Transform teleportTo)
    {
        Vector3 worldPos = teleportTo.transform.parent.TransformPoint(teleportTo.position);

        //Vector3 newPos = new Vector3(worldPos.x, worldPos.y + Player.transform.position.y, worldPos.z);
        Player.transform.position = Player.transform.parent.InverseTransformPoint(worldPos);
    }
}
