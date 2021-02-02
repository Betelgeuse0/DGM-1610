using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10.0f;
    public float max_speed = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 rvel = rb.velocity;

        if (rvel.x < max_speed && Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(force, 0, 0), ForceMode.Force);
        }

        if (rvel.z < max_speed && Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(0, 0, force), ForceMode.Force);
        }

        if (rvel.z > -max_speed && Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(0, 0, -force), ForceMode.Force);
        }

        if (rvel.x > -max_speed && Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(-force, 0, 0), ForceMode.Force);
        }

        if (rvel.y < max_speed && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, force, 0), ForceMode.Force);
        }
    }
}
