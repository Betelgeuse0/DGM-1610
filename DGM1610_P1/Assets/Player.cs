using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float walkForce = 10.0f;
    public float jumpForce = 100.0f;
    public float maxFloorSpeed = 2.0f;
    public float maxAirSpeed = 1.0f;
    public float rotationSpeed = 10.0f;
    private bool jumped = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    //use FixedUpdate when applying forces to RigidBodies (syncs with physics)
    void FixedUpdate()  
    {
        //movement logic
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveVel = new Vector3(0, 0, 0);
        bool onGround = OnGround();

        float maxSpeed = maxFloorSpeed;

        if (!onGround)
        {
            maxSpeed = maxAirSpeed;
        }

        if ((v > 0 && rb.velocity.x < maxSpeed) || (v < 0 && rb.velocity.x > -maxSpeed)) 
        {
            moveVel.x = v;
        }
        
        if ((h < 0 && rb.velocity.z < maxSpeed) || (h > 0 && rb.velocity.z > -maxSpeed)) 
        {
            moveVel.z = -h;
        }
        
        moveVel.Normalize();
        moveVel *= walkForce;

        rb.AddForce(moveVel);

        //jumping logic
        if (Input.GetKey(KeyCode.Space))
        {
            if (!jumped && onGround) 
            {
                rb.AddForce(new Vector3(0, jumpForce, 0));
                jumped = true;
            }
        }
        else if (rb.velocity.y > 0.0f)  //stop the jump short
        {
            rb.AddForce(new Vector3(0, -rb.velocity.y, 0));    
        }
        
        if (rb.velocity.y <= 0.0f)
        {
            jumped = false;
        }
        
        Vector3 rotation = transform.eulerAngles;
        rotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }

    bool OnGround()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (GetComponent<BoxCollider>().size.y / 2.0f) + 0.01f);
    }
}
