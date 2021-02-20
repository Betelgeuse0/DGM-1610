using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Importance
    {
        Low,
        Medium,
        High,
        Urgant
    }
    public Importance imp = Importance.High;
    
    void Start()
    {
        switch (imp)
        {
            case Importance.Low:
                Debug.Log("low importance...");
                break;
            case Importance.Medium:
                Debug.Log("medium importance...");
                break;
            case Importance.High:
                Debug.Log("now we're getting somewhere");
                break;
            case Importance.Urgant:
                Debug.Log("WE ARE REACHING MAXIMUM IMPORTANCE LEVELS!!!!");
                break;
            default:
                Debug.Log("This doesn't seem very important");
                break;
        }
    }
}
