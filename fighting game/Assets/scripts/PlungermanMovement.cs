using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungermanMovement : MonoBehaviour

{
    public float moveSpeed = 5f; // Adjust this to control movement speed
    private Rigidbody rb;

    public bool crouchPosition;
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
        animator.SetBool("Walk_Back", false);
        animator.SetBool("Walk_Forward", false);
        animator.SetTrigger("HighKick");
    }

    void walkForward()
    {
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
            animator.SetBool("Walk_Back", false);
            animator.SetBool("Walk_Forward", false);
            animator.SetTrigger("Crouch");
            crouchPosition = true;
        }
        else
        {
            animator.SetBool("Walk_Back", false);
            animator.SetBool("Walk_Forward", false);
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
                crouchKick();
            }

            if (crouchPosition == false)
            {
                highKick();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            walkForward();
        }

        else
        {
            animator.SetBool("Walk_Forward", false);
            animator.SetBool("Idle", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            walkBack();
        }

        else
        {
            animator.SetBool("Walk_Back", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch();
        }
        
    }
}

