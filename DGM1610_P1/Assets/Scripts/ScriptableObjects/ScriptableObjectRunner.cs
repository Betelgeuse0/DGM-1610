﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectRunner : MonoBehaviour
{
    private FloatData floatData;
    private IntData intData;
    private Vector3Data vecData;
    
    void Start()
    {
        floatData = ScriptableObject.CreateInstance<FloatData>();
        intData = ScriptableObject.CreateInstance<IntData>();
        
        //float data output
        {
            Debug.Log("*TESTING FLOAT DATA*");
            
            float data = 125.867f;
            floatData = data;
            
            Debug.Log("Expected Value (125.867), Value Received: " + floatData);
            
            floatData = 884.2f;
            data = floatData;
            
            Debug.Log("Expected Value (884.2), Value Received: " + data);


            string dataStr = "0.08853";
            floatData = dataStr;
            
            Debug.Log("Expected Value (0.08853), Value Received: " + floatData);

            floatData = "1.02";
            dataStr = floatData;
            
            Debug.Log("Expected Value (1.02), Value Received: " + dataStr);
        }
        
        //int data output
        {
            Debug.Log("*TESTING INT DATA*");
            
            int data = 125;
            intData = data;
            
            Debug.Log("Expected Value (125), Value Received: " + intData);
            
            intData = 884;
            data = intData;
            
            Debug.Log("Expected Value (884), Value Received: " + data);
            
            string dataStr = "1";
            intData = dataStr;
            
            Debug.Log("Expected Value (1), Value Received: " + intData);

            intData = "222958";
            dataStr = intData;
            
            Debug.Log("Expected Value (222958), Value Received: " + dataStr);
        }
        
        //vec data output
        {
            Debug.Log("*TESTING VEC DATA*");
            
            Vector3 data = new Vector3(0, 1, 2);
            vecData = data;
            
            Debug.Log("Expected Value (0, 1, 2), Value Received: " + vecData);
            
            vecData = new Vector3(3, 1.5f, 1000.25f);
            data = vecData;
            
            Debug.Log("Expected Value (3, 1.5, 1000.25), Value Received: " + "(" + data.x + ", " + data.y + ", " + data.z + ")");
            
        }
    }
    
}
