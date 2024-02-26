using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FireDamageHealthEffect : MonoBehaviour
{

    //public List<Image> DamageEffectSprites = new List<Image>();

    //public float animationDuration = 2f;
    //public float fadeInDuration = 0.5f;
    //public float fadeOutDuration = 0.5f;

    private float timer;
    private bool fadeIn = true;

    bool collidedWithPlayer = false;
    bool isCheck = true;

    //private void Start()
    //{
    //    for(int i = 0; i < DamageEffectSprites.Count; i++)
    //    {
    //        DamageEffectSprites[i].color = new Color(DamageEffectSprites[i].color.r, DamageEffectSprites[i].color.g, DamageEffectSprites[i].color.b, 0);
    //    }

    //}

    [SerializeField] ParticleSystem DamageEffectParticles;

    private void Update()
    {
        if (collidedWithPlayer)
        {
            //timer += Time.deltaTime;

            //if (timer <= fadeInDuration)
            //{
            //    float alpha = Mathf.Clamp01(timer / fadeInDuration);
            //    for (int i = 0; i < DamageEffectSprites.Count; i++)
            //    {
            //        DamageEffectSprites[i].color = new Color(DamageEffectSprites[i].color.r, DamageEffectSprites[i].color.g, DamageEffectSprites[i].color.b, alpha);
            //    }

            //}
            //else if (timer >= animationDuration - fadeOutDuration)
            //{
            //    float alpha = Mathf.Clamp01((animationDuration - timer) / fadeOutDuration);

            //    for (int i = 0; i < DamageEffectSprites.Count; i++)
            //    {
            //        DamageEffectSprites[i].color = new Color(DamageEffectSprites[i].color.r, DamageEffectSprites[i].color.g, DamageEffectSprites[i].color.b, alpha);
            //    }
            //}

            //if (timer >= animationDuration)
            //{
            //    timer = 0f;
            //    collidedWithPlayer = false;
            //}
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Plyaer Collided");
            if (isCheck)
            {
                collidedWithPlayer = true;
                timer = 0;


                isCheck = false;
                StartCoroutine(waitForisChecktoTrue());
            }
        }
    }


    IEnumerator waitForisChecktoTrue()
    {
        yield return new WaitForSeconds(3);
        isCheck = true;
    }


}
