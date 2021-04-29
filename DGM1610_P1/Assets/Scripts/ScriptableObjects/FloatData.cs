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
    
    public FloatData(float value) => v = value;
    public FloatData() => v = 0.0f;
    
    public static implicit operator FloatData(float value) => new FloatData(value);                     //FloatData = float
    public static implicit operator float(FloatData floatData) => floatData.v;                          //float = FloatData
    public static implicit operator FloatData(string valueStr) => new FloatData(float.Parse(valueStr)); //FloatData = string
    public static implicit operator string(FloatData floatData) => floatData.v.ToString();              //string = FloatData
}
