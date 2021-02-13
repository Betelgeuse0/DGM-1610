using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckaxe : MonoBehaviour
{
    public float swingTime = 0.25f;
    private float swingTimer = 0;
    public float swingRotate = 0;
    private Vector3 angle = new Vector3(0, 0, 0);
    private GameObject playerObj;

    void Start()
    {
        playerObj = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
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

        transform.eulerAngles = playerObj.transform.eulerAngles + angle;
    }
}
