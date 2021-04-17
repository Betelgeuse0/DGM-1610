using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParamsEvent : UnityEvent<string, int>
{
    
}

public class UnityEventBehaviour : MonoBehaviour
{
    UnityEvent myEvent;
    ParamsEvent paramsEvent;
    
    void Start()
    {
        myEvent = new UnityEvent();
        myEvent.AddListener(FireFunction);
        myEvent.AddListener(AnotherFireFunction);

        paramsEvent = new ParamsEvent();
        paramsEvent.AddListener(FireFunctionWithParams);
        
        myEvent.Invoke();
        paramsEvent.Invoke("hello", 22);
        paramsEvent.Invoke("jdawgs", 8008135);
    }
    
    void FireFunction()
    {
        Debug.Log("You fired a function");
    }

    void AnotherFireFunction()
    {
        Debug.Log("You fired ANOTHER function");
    }

    void FireFunctionWithParams(string str, int num)
    {
        Debug.Log($"The string you passed is \"{str}\" and the number you passed is \"{num}\"");
    }
    
}
