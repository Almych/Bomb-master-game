using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlaySoundEffect :  MonoBehaviour
{
     private AudioSource source;
    private static int play = 1;
    [SerializeField] private AudioClip effect;
    

    private void Start()
    {
        source = GameObject.FindGameObjectWithTag("Effect").GetComponent<AudioSource>();
    }
    public void PlayEffect ()
    {
        source.PlayOneShot(effect);
    }

    public void PlayStart ()
    {
        source.PlayOneShot(effect);
        StartCoroutine(ChangeScene());
    }
    private IEnumerator ChangeScene ()
    {
        yield return new WaitForSeconds(effect.length);
        SceneManager.LoadScene(play);
    }

}
