using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    private float v;
    public float Value { get { return v; } set { v = value; } }                     //example: FloatData data(); data.Value = 100.0f; float v = data.Value;
    
    public static implicit operator FloatData(float value)                      //FloatData = float
    {
        FloatData floatData = ScriptableObject.CreateInstance<FloatData>();
        floatData.v = value;
        return floatData;
    }
    
    public static implicit operator float(FloatData floatData) => floatData.v;  //float = FloatData

    public static implicit operator FloatData(string valueStr)
    {
        FloatData floatData = ScriptableObject.CreateInstance<FloatData>();
        floatData.v = float.Parse(valueStr);
        return floatData;
    }
    
    public static implicit operator string(FloatData floatData) => floatData.v.ToString();    //string = FloatData        
    
    public static string operator +(string str, FloatData floatData) => str + floatData.v;    //string + FloatData
    
}
