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
    private GameObject mainCamera;         
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        mainCamera = transform.GetChild(0).gameObject;
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
        Vector3 hVel = new Vector3(hForce2 * Time.deltaTime, rb.velocity.y, hForce * Time.deltaTime);
        Vector3 vVel = new Vector3(vForce2 * Time.deltaTime, rb.velocity.y, vForce * Time.deltaTime);
        Vector3 vel = hVel + vVel;
        rb.velocity = vel;

        //jumping logic
        bool onGround = OnGround();

        if (Input.GetKey(KeyCode.Space))
        {
            if (!jumped && onGround) 
            {
                rb.AddForce(new Vector3(0, jumpForce, 0));
                jumped = true;
                Debug.Log("jumped");
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
        rotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        rotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }

    bool OnGround()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (GetComponent<BoxCollider>().size.y / 2.0f) + 0.5f);
    }
}
