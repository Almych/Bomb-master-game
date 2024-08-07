using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIndAudioSource : MonoBehaviour
{
  
    private GameObject menuScene;
    void Awake()
    {
        menuScene = GameObject.FindGameObjectWithTag("Finish");
        if (menuScene!= null)
        menuScene.SetActive(false);
    }

   
}
