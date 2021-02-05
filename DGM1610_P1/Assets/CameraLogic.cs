using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private Player playerScript;

    void Start()
    {
        player = transform.parent.gameObject;
        playerScript = transform.parent.gameObject.GetComponent<Player>();
        Cursor.lockState = CursorLockMode.Locked;
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
            //lock and unlock the mouse depending on the input
            if (Input.GetKey(KeyCode.Escape))
                Cursor.lockState = CursorLockMode.None;
            else if (Input.GetMouseButtonDown(0)) 
                Cursor.lockState = CursorLockMode.Locked;
            
            //rotate the camera with mouse
            Vector3 rotation = transform.eulerAngles;
            rotation.x -= Input.GetAxis("Mouse Y") * playerScript.rotationSpeed * Time.deltaTime;
            rotation.y += Input.GetAxis("Mouse X") * playerScript.rotationSpeed * Time.deltaTime;
            transform.eulerAngles = rotation;
    }
}
