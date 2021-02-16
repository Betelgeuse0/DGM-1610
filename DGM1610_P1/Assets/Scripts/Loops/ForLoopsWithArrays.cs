using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoopsWithArrays : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("\n STARTING FOR SCRIPT \n");

        int[] pins = {1235, 5321, 9184, 0912, 9184};
        string[] people = {"mang", "waffle", "peach", "biscuit", "cherry"};

        for (int i = 0; i < pins.Length; i++)
        {
            Debug.Log(people[i] + "'s pin is: " + pins[i]);
        }
    }
}
