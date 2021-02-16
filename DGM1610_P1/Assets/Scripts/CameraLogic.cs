using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerObj;
    private Player playerScript;

    void Start()
    {
        //playerObj = transform.parent.gameObject;
       // playerScript = transform.parent.gameObject.GetComponent<Player>();
        playerScript = playerObj.GetComponent<Player>();
        Cursor.lockState = CursorLockMode.Locked;
        //transform.LookAt(playerObj.transform);
        //transform.position = playerObj.transform.position + new Vector3(0, (playerObj.GetComponent<BoxCollider>().size.y / 2.0f) + 0.5f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
            //lock and unlock the mouse depending on the input
            if (Input.GetKey(KeyCode.Escape))
                Cursor.lockState = CursorLockMode.None;
            else if (Input.GetMouseButtonDown(0)) 
                Cursor.lockState = CursorLockMode.Locked;

        transform.position = playerObj.transform.position + new Vector3(0, (playerObj.GetComponent<BoxCollider>().size.y / 2.0f) + 0.5f, 0);
        Vector3 euler = transform.eulerAngles;

        euler.x -= Input.GetAxis("Mouse Y") * playerScript.rotationSpeed * Time.deltaTime;
        euler.y += Input.GetAxis("Mouse X") * playerScript.rotationSpeed * Time.deltaTime;
        
        //smooth transitioning with clamping
        if (euler.x < 0) {
            euler.x += 359;
        }
        else if (euler.x > 359) {
            euler.x -= 359;
        }

        euler.x = euler.x < (90 + playerScript.rotationSpeed * Time.deltaTime) ? Mathf.Clamp(euler.x, 0, 80) : Mathf.Clamp(euler.x, 270, 359);

        transform.eulerAngles = euler;
    }
}
