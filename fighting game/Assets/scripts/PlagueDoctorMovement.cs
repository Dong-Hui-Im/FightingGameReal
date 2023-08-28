using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueDoctorMovement : MonoBehaviour

{
    public float moveSpeed = 5f; // Adjust this to control movement speed
    private Rigidbody rb;   // rigid body variable

    public bool crouchPosition; // crouch variable 
    public Animator animator;   // Animation variable

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // gets the rigid body
        crouchPosition = false; // makes the crouch position false so the player starts standing
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal input is equal to any horizontal input 
        float horizontalInput = Input.GetAxis("Horizontal");

        // moves the player in the direction of the horizontal input
        Vector2 moveDirection = new Vector2(horizontalInput, 0).normalized;
        Vector2 moveVelocity = moveDirection * moveSpeed;
        // rigid body velocity = moving velocity
        rb.velocity = moveVelocity;
    }
}

