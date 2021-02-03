using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public float rotationSpeed = 10;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
            /*Vector3 rotation = transform.eulerAngles;
            rotation.x += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.eulerAngles = rotation;*/

            Camera cam = GetComponent<Camera>();

            if (Input.GetKey(KeyCode.Escape))
                Cursor.lockState = CursorLockMode.None;
            else if (Input.GetMouseButtonDown(0)) {
                Cursor.lockState = CursorLockMode.Locked;
            }
            
            /*timer += Time.deltaTime;
            if (timer > 1.0f) 
                Debug.Log(Input.mousePosition);*/
            

            float h = rotationSpeed * Input.GetAxis("Mouse X");
            float v = rotationSpeed * Input.GetAxis("Mouse Y");

            //transform.Rotate(-v, h, 0);

           Vector3 rotation = transform.eulerAngles;
            rotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            rotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            transform.eulerAngles = rotation;
    }
}
