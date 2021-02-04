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
        //movement logic
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude < maxSpeed)
            rb.AddForce(new Vector3(walkForce * v, 0, -walkForce * h));

        //jumping logic
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (GetComponent<BoxCollider>().size.y / 2.0f) + 0.01f))
            if (Input.GetKeyDown(KeyCode.Space))
                rb.AddForce(new Vector3(0, jumpForce, 0));

        /*if (grounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
            grounded = false;
        }*/
        
        Vector3 rotation = transform.eulerAngles;
        //rotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        rotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;

    }

    /*void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "block" && coll.gameObject.transform.position.y < transform.position.y)
        {
            grounded = true;
        }
    }*/

}
