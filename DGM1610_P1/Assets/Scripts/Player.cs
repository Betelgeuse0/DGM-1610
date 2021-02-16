using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float walkForce = 10.0f;
    public float jumpForce = 100.0f;
    public float rotationSpeed = 10.0f;
    private bool jumped = false;
    //private GameObject mainCamera;         
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //mainCamera = transform.GetChild(0).gameObject;
        //GetComponent<MeshRenderer>().enabled = false;
    }

    //use FixedUpdate when applying forces to RigidBodies (syncs with physics)
    void FixedUpdate()  
    {
        //movement logic
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float hForce = Mathf.Cos(transform.eulerAngles.y * Mathf.PI / 180) * walkForce * v;
        float hForce2 = Mathf.Sin(transform.eulerAngles.y * Mathf.PI / 180) * walkForce * v;
        float vForce = Mathf.Cos((transform.eulerAngles.y + 90) * Mathf.PI / 180) * walkForce * h;
        float vForce2 = Mathf.Sin((transform.eulerAngles.y + 90) * Mathf.PI / 180) * walkForce * h;
        Vector3 hVel = new Vector3(hForce2 * Time.deltaTime, 0, hForce * Time.deltaTime);
        Vector3 vVel = new Vector3(vForce2 * Time.deltaTime, 0, vForce * Time.deltaTime);
        Vector3 vel = rb.velocity;
        vel += hVel + vVel;
        rb.velocity = vel;

        //jumping logic
        bool onGround = OnGround();

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

        Vector3 euler = transform.eulerAngles;

        euler.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        //if (transform.eulerAngles)
        euler.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        //rotation.x = rotation.x < 225 && rotation.x > 0 ? Mathf.Clamp(rotation.x, 0, 80) : Mathf.Clamp(rotation.x, 280, 360); //down is 90, up is 270
        
        //smooth transitioning with clamping
        if (euler.x < 0) {
            euler.x += 359;
        }
        else if (euler.x > 359) {
            euler.x -= 359;
        }

        euler.x = euler.x < (90 + rotationSpeed * Time.deltaTime) ? Mathf.Clamp(euler.x, 0, 80) : Mathf.Clamp(euler.x, 270, 359);

        transform.eulerAngles = euler;
    }

    bool OnGround()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (GetComponent<BoxCollider>().size.y / 2.0f) + 0.5f);
    }
}
