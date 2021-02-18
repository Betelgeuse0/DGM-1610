using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    public float gravity = 0.001f;
    public float bounciness = 0.1f;
    private Vector3 velocity = new Vector3();
    private RaycastHit zHit;
    private RaycastHit xHit;
    private RaycastHit yHit;

    public Vector3 Velocity
    {
        set { velocity = value; }
        get { return velocity; }
    }

    public void ApplyPhysics(GameObject o)
    {
        ApplyGravity();
        ResolveCollisions(o);
        o.transform.position += velocity * Time.deltaTime; //update position from velocity
    }

    public void ResolveCollisions(GameObject o)
    {
        MainScript s = o.GetComponent<MainScript>();

        if (OnGround(o))
        {
           velocity.y *= -bounciness;
        }
    }

    public void ApplyGravity()
    {
        velocity.y -= gravity;
    }

    public void ApplyForce(Vector3 force)
    {
        velocity += force;
    }

    public bool OnGround(GameObject o)
    {
        Debug.Log(o.GetComponent<BoxCollider>().size.y);
        return Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.down), out yHit, (o.GetComponent<BoxCollider>().size.y / 2.0f));
    }

    public bool OnCeiling(GameObject o)
    {
        return Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.up), out yHit, (o.GetComponent<BoxCollider>().size.y / 2.0f));
    }

    public bool onWall(GameObject o)
    {
        return Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.forward), out zHit, (o.GetComponent<BoxCollider>().size.y / 2.0f))
            || Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.back), out zHit, (o.GetComponent<BoxCollider>().size.y / 2.0f))
            || Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.left), out xHit, (o.GetComponent<BoxCollider>().size.y / 2.0f))
            || Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.right), out xHit, (o.GetComponent<BoxCollider>().size.y / 2.0f));
    }
}
