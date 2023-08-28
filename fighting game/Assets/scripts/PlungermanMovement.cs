using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungermanMovement : MonoBehaviour

{
    public float moveSpeed = 5f; // Adjust this to control movement speed
    private Rigidbody rb;  // rigid body variable

    public bool crouchPosition; // crouch variable 
    public Animator animator; // Animation variable

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // gets the rigid body
        crouchPosition = false;  // makes the crouch position false so the player starts standing
    }

    // highkick function
    void highKick()
    {
        // turn all the animations off except for highkick
        animator.SetBool("Walk_Back", false);
        animator.SetBool("Walk_Forward", false);
        animator.SetTrigger("HighKick");
    }
    // walk forward function
    void walkForward()
    {
        // turn all the animations off except for walk forward
        animator.SetBool("Walk_Forward", true);
        animator.SetBool("Walk_Back", false);
    }
    // walk back function
    void walkBack()
    {
        // turn all the animations off except for walk back
        animator.SetBool("Walk_Back", true);
        animator.SetBool("Walk_Forward", false);
    }
    //  crouch function
    void crouch()
    {
        // if not crouching whilst the crouch function is called
        if (crouchPosition == false)
        {
            // sets the player position into crouch and disable standing animations
            animator.SetBool("Walk_Back", false);
            animator.SetBool("Walk_Forward", false);
            animator.SetTrigger("Crouch");
            crouchPosition = true;
        }
        // else, uncrouch 
        else
        {
            animator.SetBool("Walk_Back", false);
            animator.SetBool("Walk_Forward", false);
            crouchPosition = false;
            animator.SetTrigger("Crouch");
        }
    }
    // crouch kick function
    void crouchKick()
    {
        // play the crouch kick animation
        animator.SetTrigger("Crouch_Kick");
    }
    // Update is called once per frame
    void Update()
    {
        // get the horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        // move with the horizontal input
        Vector2 moveDirection = new Vector2(horizontalInput, 0).normalized;
        Vector2 moveVelocity = moveDirection * moveSpeed;
        // rigid body velocity = moving velocity
        rb.velocity = moveVelocity;

        // if space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //  and if crouching
            if (crouchPosition == true)
            {
                // crouch kick
                crouchKick();
            }
            // if not crouching
            if (crouchPosition == false)
            {
                //  normal highkick
                highKick();
            }
        }
        // if d is pressed
        if (Input.GetKeyDown(KeyCode.D))
        {
            //  call the walk forward animation
            walkForward();
        }
        // if not
        else
        {
            // leave the animation in idle
            animator.SetBool("Walk_Forward", false);
            animator.SetBool("Idle", true);
        }

        // if a is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            //  call the walk back animation
            walkBack();
        }

        //  if not
        else
        {
            // leave the animation in idle
            animator.SetBool("Walk_Back", false);
        }

        // if s is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            //  call the crouch function
            crouch();
        }
        
    }
}

