using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public float swingTime = 0.25f;
    private float swingTimer = 0;
    public float swingRotate = 0;
    public float hitDistance = 0;
    private Vector3 angle = new Vector3(0, 0, 90);
    public GameObject mainCamera;

    void Start()
    {
        //parentObj = transform.parent.gameObject
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && swingTimer <= 0)
        {
            if (angle.x == 90)
            {
                angle.x = 90 + swingRotate;
                swingTimer = swingTime;
                DestroyTilesInFacedDirection();
            } 
        }
        else 
        {
            if (swingTimer > 0)
                swingTimer -= Time.deltaTime;
            else
                angle.x = 90;
        }
        
        transform.eulerAngles = mainCamera.transform.eulerAngles + angle;
    }
    
    void DestroyTilesInFacedDirection()
    {
        //get pointing direction in world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int layerMask = 1 << 10;
        layerMask = ~layerMask;     //ignore the Player layer
        
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit,
            hitDistance, layerMask))
        {
            GameObject obj = hit.collider.gameObject;
            Destroy(hit.collider.gameObject);
        }
    }
}
