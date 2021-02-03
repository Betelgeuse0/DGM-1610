using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    public float rotationSpeed = 10;
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
                Debug.Log(Input.mousePosition);
            }
            
    }
}
