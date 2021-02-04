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
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        //movement logic
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        /*if ((moveVel + rbVel).magnitude < maxSpeed)
            rb.AddForce(new Vector3(walkForce * v, 0, -walkForce * h));*/


        if (Mathf.Abs(rb.velocity.x) < maxSpeed || Mathf.Sign(h) != Mathf.Sign(rb.velocity.x))
        {
            rb.AddForce(new Vector3(0, 0, -walkForce * h));
            print(h + " " + rb.velocity.x);
        }

        if (Mathf.Abs(rb.velocity.y) < maxSpeed || Mathf.Sign(v) != Mathf.Sign(rb.velocity.y))
        {
            rb.AddForce(new Vector3(walkForce * v, 0, 0));
        }
        //jumping logic
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (GetComponent<BoxCollider>().size.y / 2.0f) + 0.01f)) 
            {
                rb.AddForce(new Vector3(0, jumpForce, 0));
            }
        }
        else if (!Input.GetKey(KeyCode.Space) && rb.velocity.y > 0.0f)  //stop the jump short
        {
            rb.AddForce(new Vector3(0, -rb.velocity.y, 0));    
        }
        
        Vector3 rotation = transform.eulerAngles;
        //rotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        rotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;

    }


}
