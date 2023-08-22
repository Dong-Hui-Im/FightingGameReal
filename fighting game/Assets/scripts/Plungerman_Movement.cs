using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plungerman_Movement : MonoBehaviour
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
        animator.SetTrigger("HighKick");
    }

    void walkForward()
    {
        animator.SetTrigger("Walk_Forward");
    }

    void walkBack()
    {
        animator.SetTrigger("Walk_Back");
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
            animator.SetTrigger("Uncrouch");
        } 
    }

    void crouchKick()
    {
        animator.SetTrigger("Crouch_Kick");
        crouchPosition = true;
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            walkBack();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch();
        }
    }
}

