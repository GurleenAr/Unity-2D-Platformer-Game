using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rbTwoD; 
    private Animator anim;
    private float directionX=0f;
    private SpriteRenderer sprite;
    [SerializeField] private float movingSpeed=7f;
    [SerializeField] private float jumpVelocity=14f;
    private BoxCollider2D collid;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState {idle, running, jumping, falling}
    // private bool canMove=true;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
        rbTwoD =GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
        collid=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");  //to make sure it goes back to 0 immediately and player does not slide
        rbTwoD.velocity= new Vector2(movingSpeed * directionX, rbTwoD.velocity.y);

        if(Input.GetButtonDown("Jump") && ifGrounded())
        {
            rbTwoD.velocity= new Vector2(rbTwoD.velocity.x,jumpVelocity);
            jumpSoundEffect.Play();
        }
        updateAnimation();
    }

    private void updateAnimation()
    {
        MovementState state;
        if(directionX > 0f)
        {
            state = MovementState.running;
            sprite.flipX=false;
        }
        else if(directionX <0f)
        {
            state = MovementState.running;
            sprite.flipX=true;
        }
        else
        {
            state = MovementState.idle;
        }
        if(rbTwoD.velocity.y > .1f)
        {
            state = MovementState.jumping;  
        }
        else if(rbTwoD.velocity.y < -.1f)
        {
            state = MovementState.falling;  
        }
        anim.SetInteger("state", (int)state);
    }

    private bool ifGrounded()
    {
        return Physics2D.BoxCast(collid.bounds.center, collid.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
            //jumpableGround check for overlapping with the ground
    }
    
}
