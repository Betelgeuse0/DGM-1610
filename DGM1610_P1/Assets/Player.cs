using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("up");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            Debug.Log("left");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            Debug.Log("right");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            Debug.Log("down");
        }
    }
}
