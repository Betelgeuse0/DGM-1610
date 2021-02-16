using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileLoops : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("\n STARTING WHILE SCRIPT \n");

        string[] words = {"name", "my", "is", "bob", "hi,"};
        int i = words.Length;

        while (i > 0)
        {
            --i;
            Debug.Log(words[i]);
        }

        words[2] = "cat";
        words[words.Length - 1] = "cute";
        i = 0;

        do {
            Debug.Log(words[i]);
            ++i;
        } while(i < words.Length);
    }
}
