using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VarsAndOps    //include variables.cs
{
    public class Ops
    {
        static public void StartHere()
        {
            ++Vars.myInt;
            --Vars.myLong;
            Vars.myString = Vars.myString.Substring(5, 6) + "changed man";
            Vars.myBool = !Vars.myBool;

            Debug.Log(Vars.myInt);
            Debug.Log(Vars.myLong);
            Debug.Log(Vars.myFloat);
            Debug.Log(Vars.myDecimal);
            Debug.Log(Vars.myString);
            Debug.Log(Vars.myBool);
        }

    }
}

public class Operators : MonoBehaviour
{
    void Start()
    {
        VarsAndOps.Ops.StartHere();
    }
}