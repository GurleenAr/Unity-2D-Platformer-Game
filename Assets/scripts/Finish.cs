using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private AudioSource finishSoundEffect;
    private bool levelCompleted=false;
    void Start()
    {
        finishSoundEffect= GetComponent<AudioSource>();

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="player" && !levelCompleted)
        {
            finishSoundEffect.Play();
            levelCompleted=true;
            Invoke("levelComplete",2f);
        }
    }

    private void levelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

