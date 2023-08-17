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

    void update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            highKick();
        }
    }

    void highKick()
    {
        animator.SetTrigger("HighKick");
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 moveDirection = new Vector2(horizontalInput, 0).normalized;
        Vector2 moveVelocity = moveDirection * moveSpeed;

        rb.velocity = moveVelocity;
    }
}
