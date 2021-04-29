using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    private Vector3 v;
    public Vector3 Value { get { return v; } set { v = value; } }                     //example: FloatData data(); data.Value = 100.0f; float v = data.Value;
    
    public static implicit operator Vector3Data(Vector3 value)                      //FloatData = float
    {
        Vector3Data vecData = ScriptableObject.CreateInstance<Vector3Data>();
        vecData.v = value;
        return vecData;
    }
    public static implicit operator Vector3(Vector3Data vecData) => vecData.v;  //float = FloatData
    
    public static string operator +(string str, Vector3Data vecData) => str + "(" + vecData.v.x + ", " + vecData.v.y + ", " + vecData.v.z + ")";
}
