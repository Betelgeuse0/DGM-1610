using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        GameObject o = c.gameObject;
        
        if (c.gameObject.tag == "unit")
        {
            MainScript script = c.gameObject.GetComponent<MainScript>();
            //script.Velocity *= -1;
        }
    }
}
