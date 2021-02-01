using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector3(force, 0, 0), ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(new Vector3(0, 0, force), ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(new Vector3(0, 0, -force), ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(new Vector3(-force, 0, 0), ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, force, 0), ForceMode.Force);
        }
    }
}
