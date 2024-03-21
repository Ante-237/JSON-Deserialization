using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonDeserialization : MonoBehaviour
{
    private readonly string fileName = "data.json";

   
    public WorkOut JsonReader()
    {
        string filePath = Path.Combine(Application.dataPath, fileName);
        // Debug.Log(filePath);

        if (!File.Exists(filePath))
        {
            Debug.LogWarning("File not Found!!");
        }

        string jsonData = File.ReadAllText(filePath);
        Debug.Log(jsonData);
        
        WorkOut info = JsonUtility.FromJson<WorkOut>(jsonData);
        return info;

       
    }
}
