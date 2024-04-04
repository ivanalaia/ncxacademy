using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float raycastHeight = 1.2f;

    public LayerMask groundLayer;

    public static PlayerController instance;

    public AudioSource jumpAudio, gameOverAudio, BGMAudio;

    public bool isDead;

    bool isJumping, gameOverAudioPlayed;
    
    Rigidbody2D playerBody;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        AnimationControl();
        if(isDead == false)
        {
            JumpControl();
        }
        else
        {
            if(gameOverAudioPlayed == false)
            {
                gameOverAudioPlayed = true;
                gameOverAudio.Play();
                BGMAudio.Stop();

            }


        }
    }

    void JumpControl()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastHeight, groundLayer);

        if (hit == true)
        {
            isJumping = false;
            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                jumpAudio.Play();
                playerBody.velocity = new Vector2(0, jumpForce);
                isJumping = true;
            }
        }
        else
        {
            isJumping = true;
        }
    }

    void AnimationControl()
    {
        if(isJumping == true)
        {
            anim.SetTrigger("Jump");
            anim.SetBool("isRunning", !isJumping);
        }
        if (isDead == true)
            {
            anim.SetBool("isRunning", false);
            anim.SetTrigger("Dead");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.down * raycastHeight);

    }
}
