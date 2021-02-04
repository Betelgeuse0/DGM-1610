using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float walkForce = 10.0f;
    public float jumpForce = 100.0f;
    public float maxSpeed = 2.0f;
    public float rotationSpeed = 10.0f;
    private bool grounded = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude < maxSpeed)
            rb.AddForce(new Vector3(walkForce * v, 0, -walkForce * h));

        if (grounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            grounded = false;
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
        
        Vector3 rotation = transform.eulerAngles;
        //rotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        rotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "block")
        {
            grounded = true;
        }
    }
}
