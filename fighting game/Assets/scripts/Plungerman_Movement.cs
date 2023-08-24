using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plungerman_Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control movement speed
    private Rigidbody rb;

    public bool crouchPosition;

    public bool isWalkingF = false;

    public Animator animator;

    private 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        crouchPosition = false;
    }

    void highKick()
    {
        animator.SetTrigger("HighKick");
    }

    void walkForward()
    {
        isWalkingF = true;
        animator.SetBool("Walk_Forward", true);
        animator.SetBool("Walk_Back", false);
    }

    void walkBack()
    {
        animator.SetBool("Walk_Back", true);
        animator.SetBool("Walk_Forward", false);
    }

    void crouch()
    {
        if (crouchPosition == false)
        {
            animator.SetTrigger("Crouch");
            crouchPosition = true;
        }
        else
        {
            crouchPosition = false;
            animator.SetTrigger("Crouch");
        } 
    }

    void crouchKick()
    {
        animator.SetTrigger("Crouch_Kick");
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 moveDirection = new Vector2(horizontalInput, 0).normalized;
        Vector2 moveVelocity = moveDirection * moveSpeed;

        rb.velocity = moveVelocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (crouchPosition == true)
            {
                animator.SetBool("Idle", false);
                crouchKick();
            }

            if (crouchPosition == false)
            {
                animator.SetBool("Idle", false);
                highKick();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        { 
            animator.SetBool("Idle", false);
            walkForward();
        }

        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk_Forward", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Idle", false);
            walkBack();
        }

        else
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk_Back", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Idle", false);
            crouch();
        }

        else
        {
            animator.SetBool("Idle", true);
        }
    }
}

