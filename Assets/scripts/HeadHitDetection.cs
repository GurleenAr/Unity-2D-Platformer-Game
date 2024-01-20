using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeadHitDetection : MonoBehaviour
{
    private Animator anim;

    GameObject Enemy;
    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
        anim = GetComponent<Animator>();
        anim= gameObject.transform.parent.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Enemy.GetComponent<SpriteRenderer>().flipY=true;
        Enemy.GetComponent<Collider2D>().enabled = false;
        anim.SetTrigger("death");
        
    }

}
