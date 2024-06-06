using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] float rotSpeed;
    private void Update()
    {
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
    }
}
