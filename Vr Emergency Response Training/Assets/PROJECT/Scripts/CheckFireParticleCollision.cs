using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFireParticleCollision : MonoBehaviour
{
    private int collisionCount = 0;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("ExtParticles"))
        {
            collisionCount = PlayerPrefs.GetInt("FireCollisions");
            collisionCount++;
            PlayerPrefs.SetInt("FireCollisions", collisionCount);
            Debug.Log(PlayerPrefs.GetInt("FireCollisions"));
        }
    }

 
}
