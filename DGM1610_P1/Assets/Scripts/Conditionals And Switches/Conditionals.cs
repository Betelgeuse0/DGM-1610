using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditionals : MonoBehaviour
{
    // Start is called before the first frame update
    public int x = 50;
    public int y = 10;
    public string containing = "Hello Bob";
    void Start()
    {
        if (x > y) 
        {
            Debug.Log("Hello World");
        }
        else if (x < y)
        {
            Debug.Log("x < y");
        }
        else 
        {
            Debug.Log("x == y");
        }

        if (containing.Contains("Bob"))   //check if the string contains "Bob"
        {
            Debug.Log("Hello, Bob");
        }
        
    }
}
