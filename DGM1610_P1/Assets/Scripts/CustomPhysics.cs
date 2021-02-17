using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    public float gravity = 0.001f;
    public float bounciness = 0.1f;
    private Vector3 velocity = new Vector3();

    public Vector3 Velocity
    {
        set { velocity = value; }
        get { return velocity; }
    }

    public void ApplyPhysics(GameObject o)
    {
        ApplyGravity(o);
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

    public void ApplyGravity(GameObject o)
    {
        velocity.y -= gravity;
    }

    public bool OnGround(GameObject o)
    {
        RaycastHit hit;
        return Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.down), out hit, (o.GetComponent<BoxCollider>().size.y / 2.0f) + 0.1f);
    }

    public bool OnCeiling(GameObject o)
    {
        RaycastHit hit;
        return Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.up), out hit, (o.GetComponent<BoxCollider>().size.y / 2.0f) + 0.1f);
    }

    public bool onWall(GameObject o)
    {
        RaycastHit hit;
        return Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.forward), out hit, (o.GetComponent<BoxCollider>().size.y / 2.0f) + 0.1f)
            || Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.back), out hit, (o.GetComponent<BoxCollider>().size.y / 2.0f) + 0.1f)
            || Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.left), out hit, (o.GetComponent<BoxCollider>().size.y / 2.0f) + 0.1f)
            || Physics.Raycast(o.transform.position, o.transform.TransformDirection(Vector3.right), out hit, (o.GetComponent<BoxCollider>().size.y / 2.0f) + 0.1f);
    }
}
