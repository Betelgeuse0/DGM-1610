using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject playerObj;
    private Player playerScript;

    void Start()
    {
        playerObj = transform.parent.gameObject;
        playerScript = transform.parent.gameObject.GetComponent<Player>();
        Cursor.lockState = CursorLockMode.Locked;
        transform.LookAt(playerObj.transform);
        transform.position = playerObj.transform.position + new Vector3(0, (playerObj.GetComponent<BoxCollider>().size.y / 2.0f) + 0.5f, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
            //lock and unlock the mouse depending on the input
            if (Input.GetKey(KeyCode.Escape))
                Cursor.lockState = CursorLockMode.None;
            else if (Input.GetMouseButtonDown(0)) 
                Cursor.lockState = CursorLockMode.Locked;

            transform.eulerAngles = playerObj.transform.eulerAngles;
    }
}
