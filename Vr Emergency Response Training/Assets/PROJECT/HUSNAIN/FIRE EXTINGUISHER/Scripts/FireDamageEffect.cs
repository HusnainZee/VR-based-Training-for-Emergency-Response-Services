using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamageEffect : MonoBehaviour
{

    [SerializeField] List<ParticleSystem> DamageEffectParticles = new List<ParticleSystem>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Collided");
            for(int i = 0; i < DamageEffectParticles.Count; i++)
            {
                DamageEffectParticles[i].Play();
            }
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player not Collided");
            for (int i = 0; i < DamageEffectParticles.Count; i++)
            {
                DamageEffectParticles[i].Stop();
            }
        }
    }
}
