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
    private CustomPhysics physicsScript;

    void Start()
    {
        physicsScript = GetComponent<CustomPhysics>();
        physicsScript.ResolveCollisions(gameObject);
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
        Vector3 hVel = new Vector3(hForce2, 0, hForce);
        Vector3 vVel = new Vector3(vForce2, 0, vForce);
        physicsScript.Velocity = hVel + vVel;
        //jumping logic
        bool onGround = physicsScript.OnGround(gameObject);

        if (Input.GetKey(KeyCode.Space))
        {
            if (!jumped && onGround) 
            {
                //rb.AddForce(new Vector3(0, jumpForce, 0));
                physicsScript.ApplyForce(new Vector3(0, jumpForce, 0));
                jumped = true;
            }
        }
        else if (physicsScript.Velocity.y > 0.0f)  //stop the jump short
        {
            /*Vector3 vel = physicsScript.Velocity;
            vel.y = 0;
            physicsScript.Velocity = vel;*/

            //physicsScript.ApplyForce(new Vector3(0, -physicsScript.Velocity.y / 2, 0));
            //rb.AddForce(new Vector3(0, -rb.velocity.y, 0));    
        }
        
        if (physicsScript.Velocity.y <= 0.0f)
        {
            jumped = false;
        }


        //angle
        Vector3 euler = mainCamera.transform.eulerAngles;
        euler.x = 0;
        transform.eulerAngles = euler;

        physicsScript.ApplyPhysics(gameObject);
    }
}
