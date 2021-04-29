using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPhysics : MonoBehaviour
{
    public float gravity = 0.001f;
    public float maxGravity = 0.1f;
    public float bounciness = 0.1f;
    private Vector3 velocity = new Vector3();
    private RaycastHit zHit;
    private RaycastHit xHit;
    private RaycastHit yHit;
    private int layerMask = ~(1 << 10); //ignore the Player layer
    
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

        if (OnGround(o) && velocity.y < 0)  //onGround and falling
        {
           velocity.y *= -bounciness;
        }

        if (OnCeiling(o) && velocity.y > 0) //onCeiling and rising
        {
            velocity.y *= -bounciness;
            //Debug.Log(yHit.collider.gameObject);
        }
        
        if (onWallX(o))
        {
            if ((xHit.point.x < o.transform.position.x && velocity.x < 0) || (xHit.point.x > o.transform.position.x && velocity.x > 0))
                velocity.x *= -bounciness;
        }
        
        float sizeFactor = o.GetComponent<BoxCollider>().size.x * 0.5f;
        float rayDist = sizeFactor + 0.1f;
        Vector3 position = o.transform.position;
        position.y += 0.1f;
        Vector3 origin1 = position + new Vector3(0, sizeFactor, sizeFactor);
        Vector3 origin2 = position + new Vector3(0, -sizeFactor, sizeFactor);
        Vector3 origin3 = position + new Vector3(0, sizeFactor, -sizeFactor);
        Vector3 origin4 = position + new Vector3(0, -sizeFactor, -sizeFactor);
        Debug.DrawRay(origin1, Vector3.left * rayDist, Color.red); 
        Debug.DrawRay(origin2, Vector3.left * rayDist, Color.red); 
        Debug.DrawRay(origin3, Vector3.left * rayDist, Color.red); 
        Debug.DrawRay(origin4, Vector3.left * rayDist, Color.red);
        Debug.DrawRay(origin1, Vector3.right * rayDist, Color.red); 
        Debug.DrawRay(origin2, Vector3.right * rayDist, Color.red); 
        Debug.DrawRay(origin3, Vector3.right * rayDist, Color.red); 
        Debug.DrawRay(origin4, Vector3.right * rayDist, Color.red); 
        
        origin1 = position + new Vector3(sizeFactor, sizeFactor, 0);
        origin2 = position + new Vector3(sizeFactor, -sizeFactor, 0);
        origin3 = position + new Vector3(-sizeFactor, sizeFactor, 0);
        origin4 = position + new Vector3(-sizeFactor, -sizeFactor, 0);
        
        Debug.DrawRay(origin1, Vector3.back * rayDist, Color.red); 
        Debug.DrawRay(origin2, Vector3.back * rayDist, Color.red); 
        Debug.DrawRay(origin3, Vector3.back * rayDist, Color.red); 
        Debug.DrawRay(origin4, Vector3.back * rayDist, Color.red); 
        Debug.DrawRay(origin1, Vector3.forward * rayDist, Color.red); 
        Debug.DrawRay(origin2, Vector3.forward * rayDist, Color.red); 
        Debug.DrawRay(origin3, Vector3.forward * rayDist, Color.red); 
        Debug.DrawRay(origin4, Vector3.forward * rayDist, Color.red); 

        
        if (onWallZ(o))
        {
            if ((zHit.point.z < o.transform.position.z && velocity.z < 0) || (zHit.point.z > o.transform.position.z && velocity.z > 0))
                velocity.z *= -bounciness;
        }

    }

    public void ApplyGravity()
    {
        if (velocity.y > -maxGravity)
            velocity.y -= gravity;
    }

    public void ApplyForce(Vector3 force)
    {
        velocity += force;
    }
    
    //note these functions likely only work properly if the dimensions of the box collider xyz are all the same
    public bool OnGround(GameObject o)
    {
        //Debug.Log("on ground");
        //raycast on all 4 corners
        float sizeFactor = o.GetComponent<BoxCollider>().size.y * 0.5f;
        Vector3 position = o.transform.position;
        Vector3 origin1 = position + new Vector3(sizeFactor, 0, sizeFactor);
        Vector3 origin2 = position + new Vector3(-sizeFactor, 0, sizeFactor);
        Vector3 origin3 = position + new Vector3(sizeFactor, 0, -sizeFactor);
        Vector3 origin4 = position + new Vector3(-sizeFactor, 0, -sizeFactor);
        return Physics.Raycast(origin1, Vector3.down, out yHit, sizeFactor, layerMask)
               || Physics.Raycast(origin2, Vector3.down, out yHit, sizeFactor, layerMask)
               || Physics.Raycast(origin3, Vector3.down, out yHit, sizeFactor, layerMask)
               || Physics.Raycast(origin4, Vector3.down, out yHit, sizeFactor, layerMask);
    }
    
    public bool OnCeiling(GameObject o)
    {        
        //Debug.Log("on ceiling");

        //raycast on all 4 corners
        float sizeFactor = o.GetComponent<BoxCollider>().size.y * 0.5f;
        Vector3 position = o.transform.position;
        position.x -= 0.1f;
        position.z -= 0.1f;
        Vector3 origin1 = position + new Vector3(sizeFactor, 0, sizeFactor);
        Vector3 origin2 = position + new Vector3(-sizeFactor, 0, sizeFactor);
        Vector3 origin3 = position + new Vector3(sizeFactor, 0, -sizeFactor);
        Vector3 origin4 = position + new Vector3(-sizeFactor, 0, -sizeFactor);
        return Physics.Raycast(origin1, Vector3.up, out yHit, sizeFactor + 0.8f, layerMask)
               || Physics.Raycast(origin2, Vector3.up, out yHit, sizeFactor + 0.8f, layerMask)
               || Physics.Raycast(origin3, Vector3.up, out yHit, sizeFactor + 0.8f, layerMask)
               || Physics.Raycast(origin4, Vector3.up, out yHit, sizeFactor + 0.8f, layerMask);
    }

    public bool onWallX(GameObject o)
    {
        //raycast on all 4 corners
        float sizeFactor = o.GetComponent<BoxCollider>().size.x * 0.5f;
        float rayDist = sizeFactor + 0.1f;
        Vector3 position = o.transform.position;
        position.y += 0.1f;
        
        Vector3 origin1 = position + new Vector3(0, sizeFactor, sizeFactor);
        Vector3 origin2 = position + new Vector3(0, -sizeFactor, sizeFactor);
        Vector3 origin3 = position + new Vector3(0, sizeFactor, -sizeFactor);
        Vector3 origin4 = position + new Vector3(0, -sizeFactor, -sizeFactor);
        
        return Physics.Raycast(origin1, Vector3.left, out xHit, rayDist, layerMask)
               || Physics.Raycast(origin2, Vector3.left, out xHit, rayDist, layerMask)
               || Physics.Raycast(origin3, Vector3.left, out xHit, rayDist, layerMask)
               || Physics.Raycast(origin4, Vector3.left, out xHit, rayDist, layerMask)
               || Physics.Raycast(origin1, Vector3.right, out xHit, rayDist, layerMask)
               || Physics.Raycast(origin2, Vector3.right, out xHit, rayDist, layerMask)
               || Physics.Raycast(origin3, Vector3.right, out xHit, rayDist, layerMask)
               || Physics.Raycast(origin4, Vector3.right, out xHit, rayDist, layerMask);
    }

    public bool onWallZ(GameObject o)
    {
        //raycast on all 4 corners
        float sizeFactor = o.GetComponent<BoxCollider>().size.x * 0.5f;
        float rayDist = sizeFactor + 0.1f;
        Vector3 position = o.transform.position;
        position.y += 0.1f;
        
        Vector3 origin1 = position + new Vector3(sizeFactor, sizeFactor, 0);
        Vector3 origin2 = position + new Vector3(sizeFactor, -sizeFactor, 0);
        Vector3 origin3 = position + new Vector3(-sizeFactor, sizeFactor, 0);
        Vector3 origin4 = position + new Vector3(-sizeFactor, -sizeFactor, 0);
        
        return Physics.Raycast(origin1, Vector3.forward, out zHit, rayDist, layerMask)
               || Physics.Raycast(origin2, Vector3.forward, out zHit, rayDist, layerMask)
               || Physics.Raycast(origin3, Vector3.forward, out zHit, rayDist, layerMask)
               || Physics.Raycast(origin4, Vector3.forward, out zHit, rayDist, layerMask)
               || Physics.Raycast(origin1, Vector3.back, out zHit, rayDist, layerMask)
               || Physics.Raycast(origin2, Vector3.back, out zHit, rayDist, layerMask)
               || Physics.Raycast(origin3, Vector3.back, out zHit, rayDist, layerMask)
               || Physics.Raycast(origin4, Vector3.back, out zHit, rayDist, layerMask);
    }
}
