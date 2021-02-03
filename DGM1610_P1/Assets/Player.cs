using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10.0f;
    public float max_speed = 2.0f;
    public float rotationSpeed = 10.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude < max_speed)
            rb.AddForce(new Vector3(force * v, 0, -force * h));
        
        Vector3 rotation = transform.eulerAngles;
        //rotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        rotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
}
