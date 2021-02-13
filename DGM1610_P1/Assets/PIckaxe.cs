using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckaxe : MonoBehaviour
{
    public float swingTime = 0.25f;
    private float swingTimer = 0;
    public float swingRotate = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (transform.eulerAngles.x == 0)
            {
                Vector3 angle = transform.eulerAngles;
                angle.x += swingRotate;
                transform.eulerAngles = angle;
                swingTimer = swingTime;
            }
        }
        else 
        {
            if (swingTimer > 0)
                swingTimer -= Time.deltaTime;
            else if (transform.rotation.x != 0.0f)
                transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
