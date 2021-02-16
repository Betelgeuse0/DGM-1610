using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeachLoopsWithArrays : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("\n STARTING FOREACH SCRIPT \n");

        float[] randomNumbers = {Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000)};

        foreach(float num in randomNumbers)
        {
            Debug.Log("random number produced: " + num);
        }
    }
}
