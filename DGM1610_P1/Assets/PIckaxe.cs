using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckaxe : MonoBehaviour
{
    private float swingTimer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion r = transform.rotation;
            r.x += 30;
            transform.rotation = r;
            swingTimer = 0.5f;
        }
        else 
        {
            if (swingTimer > 0)
                swingTimer -= Time.deltaTime;
            else if (transform.rotation.x != 0.0f)
                transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
}
