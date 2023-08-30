using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlagueDoctorMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to control movement speed
    private Rigidbody rb;   // rigid body variable

    private float horizontal;
    public float xRange = 30;  // the range of the boundary
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
        //  acquires the horizontal input
        horizontal = Input.GetAxisRaw("Horizontal2");

        //  player boundaries
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
    //  fixed update is just a more consistent form of update
    private void FixedUpdate()
    {
        //  uses the horizontal input to apply velocity to make the player move left and right
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }
}

