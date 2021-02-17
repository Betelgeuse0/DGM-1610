using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    //public Rigidbody rb;
    public float walkForce = 10.0f;
    public float jumpForce = 100.0f;
    public float rotationSpeed = 10.0f;
    private bool jumped = false;
    public GameObject mainCamera; 
    private Vector3 velocity = new Vector3(0, 0, 0);

    public Vector3 Velocity {
        set {velocity = value;}
        get {return velocity;}
    }        
    
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
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
        //Vector3 vel = rb.velocity;
        //vel += hVel + vVel;
        //rb.velocity = vel;
        velocity += hVel + vVel;
        //jumping logic
        bool onGround = OnGround();

        if (Input.GetKey(KeyCode.Space))
        {
            if (!jumped && onGround) 
            {
                //rb.AddForce(new Vector3(0, jumpForce, 0));
                jumped = true;
            }
        }
        else if (velocity.y > 0.0f)  //stop the jump short
        {
            //rb.AddForce(new Vector3(0, -rb.velocity.y, 0));    
        }
        
        if (velocity.y <= 0.0f)
        {
            jumped = false;
        }

        //gravity
        velocity.y -= 0.001f;
        Vector3 pos = transform.position + velocity;
        //apply force to position
        transform.position = pos;

        //angle
        Vector3 euler = mainCamera.transform.eulerAngles;
        euler.x = 0;
        transform.eulerAngles = euler;


    }

    bool OnGround()
    {
        RaycastHit hit;
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, (GetComponent<BoxCollider>().size.y / 2.0f) + 0.5f);
    }
}
