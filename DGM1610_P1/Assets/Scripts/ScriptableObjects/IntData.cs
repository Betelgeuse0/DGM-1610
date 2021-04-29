using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    private int v;
    public int Value { get { return v; } set { v = value; } }                     //example: FloatData data(); data.Value = 100.0f; float v = data.Value;
    
    public static implicit operator IntData(int value)                      //FloatData = float
    {
        IntData intData = ScriptableObject.CreateInstance<IntData>();
        intData.v = value;
        return intData;
    }
    
    public static implicit operator int(IntData intData) => intData.v;  //float = FloatData

    public static implicit operator IntData(string valueStr)
    {
        IntData intData = ScriptableObject.CreateInstance<IntData>();
        intData.v = int.Parse(valueStr);
        return intData;
    }
    
    public static implicit operator string(IntData intData) => intData.v.ToString();    //string = FloatData        
    
    public static string operator +(string str, IntData intData) => str + intData.v;    //string + FloatData
    
}
