﻿using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class playerCollision : MonoBehaviour
{
    public playerMovement movement;

    float value;
    public string objectifTag = "";

    void OnCollisionEnter(Collision collisionInfo)
    {
        GameObject touched = collisionInfo.collider.gameObject;
        if (collisionInfo.collider.tag == objectifTag)
        {
            touched.GetComponent<Collider>().enabled = false;
            if (FindObjectOfType<GameManager>().difficult == true)
            {
                FindObjectOfType<playerMovement>().Boost();
            }
            Debug.Log("We hit the objectif !");
            // Augmenter le score de 1 !
            FindObjectOfType<GameManager>().actualScore += 1f;
            FindObjectOfType<AudioManager>().Play("Dissolution");
            //Fais disparaitre l'objet
            disappearObject(touched);

        }
        else
        {
            GameObject touchedFalse = collisionInfo.collider.gameObject;
            if (touchedFalse.name != "Plane")
            {
                //Joue l'animation d'explosion
                touchedFalse.GetComponent<explosion>().explosionObj.GetComponent<VisualEffect>().Play();
                //Augmente l'erreur +1
                FindObjectOfType<GameManager>().error += 1f;
                //Joue le son 
                FindObjectOfType<AudioManager>().Play("Explosion");
                //Fais disparaitre l'objet
                disappearObject(touchedFalse);
            }
            
        }
        /*if(collisionInfo.collider.tag == "obstacle")
        {
            Debug.Log("We hit an obstacle !");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }*/


        
        void disappearObject(GameObject TouchedObject)
        {
            Renderer mat = collisionInfo.collider.gameObject.GetComponent<Renderer>();
            StartCoroutine(ChangeValue(0f, 1f, 0.25f, mat, TouchedObject));
        }

        IEnumerator ChangeValue(float v_start, float v_end, float duration, Renderer v_mat, GameObject TouchedObject)
        {
            float elapsed = 0.0f;
            while (elapsed < duration)
            {
                value = Mathf.Lerp(v_start, v_end, elapsed / duration);
                elapsed += Time.deltaTime;

                v_mat.material.SetFloat("Vector1_A5850407", value);
                yield return null;
            }
            value = v_end;
            v_mat.material.SetFloat("Vector1_A5850407", value);
            TouchedObject.SetActive(false);
            value = 0f;
        }
    }
  
}
