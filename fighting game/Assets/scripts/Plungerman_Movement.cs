using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plungerman_Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control movement speed
    private Rigidbody rb;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 moveDirection = new Vector2(horizontalInput, 0).normalized;
        Vector2 moveVelocity = moveDirection * moveSpeed;

        rb.velocity = moveVelocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            highKick();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            walkForward();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            walkBack();
        }
    }
}

