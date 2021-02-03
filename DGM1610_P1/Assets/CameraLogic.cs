using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public float rotationSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(transform.parent);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Quaternion rot = transform.rotation;
            //transform.rotation.SetFromToRotation(transform.position, transform.position + new Vector3(rotationSpeed, 0, 0));
            //Vector3 newRot = transform.rotation + new Quaternion(rotationSpeed, 0, 0, 0);
            //transform.rotation.Set(newRot);
        }
    }
}
