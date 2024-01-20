using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLIfe : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource deathSoundEffect;
    private Vector3 respawnPosition;

     private void Start()
     {
          anim=GetComponent<Animator>();
          rb=GetComponent<Rigidbody2D>();
          respawnPosition=transform.position;
     }
     public void death()
     {
          anim.SetTrigger("death");
          rb.bodyType=RigidbodyType2D.Static;
          deathSoundEffect.Play();
          PlayerPrefs.SetInt("Items Collected", 0);
     }
     public void hurt()
     {
          transform.position= respawnPosition;
     }

     private void restartLevel()
     {
          Debug.Log("REAACHED RESTART");
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
          
     }
}
