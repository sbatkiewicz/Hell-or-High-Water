using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Motor : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rotSpeed = 20;
    public float maxSpeed = 40f;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }


        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            rb.AddForce(transform.forward * moveSpeed);

        }

        if (Input.GetKey("left") || Input.GetKey("a"))  
        {
                transform.Rotate(0, -rotSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey("right") || Input.GetKey("d"))
        {
                transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
        }


    }
}
