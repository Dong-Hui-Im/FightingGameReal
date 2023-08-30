using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueDoctorMovement2 : MonoBehaviour

{
    public float moveSpeed = 5f; // Adjust this to control movement speed
    private Rigidbody rb;   // rigid body variable

    private float horizontal;

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
        horizontal = Input.GetAxisRaw("Horizontal2");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }
}

