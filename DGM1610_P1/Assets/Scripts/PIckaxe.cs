using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public float swingTime = 0.25f;
    private float swingTimer = 0;
    public float swingRotate = 0;
    private Vector3 angle = new Vector3(0, 0, 0);
    public GameObject parentObj;

    void Start()
    {
        //parentObj = transform.parent.gameObject
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = parentObj.transform.position + new Vector3(0.5f, 0, 0.5f);
        if (Input.GetMouseButton(0) && swingTimer <= 0)
        {
            if (angle.x == 0)
            {
                angle.x = swingRotate;
                swingTimer = swingTime;
            } 
        }
        else 
        {
            if (swingTimer > 0)
                swingTimer -= Time.deltaTime;
            else
                angle.x = 0;
        }

        //transform.eulerAngles = parentObj.transform.eulerAngles + angle;
        Vector3 euler = parentObj.transform.eulerAngles;
        //euler.x = 0;
        
        transform.eulerAngles = euler;
    }
}
