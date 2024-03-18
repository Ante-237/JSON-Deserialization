using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Palmmedia.ReportGenerator.Core.Common;
using Unity.Mathematics;
using Unity.Serialization.Json;
using UnityEngine;

//[System.Serializable]
public class BallInfo
{
    public int ballId;
    public float speed;
    public float ballDirection;
}

//[System.Serializable]
public class WorkOutInfo
{
    public int workoutID;
    public string WorkoutName;
    public string description;
    public string ballType;
    public List<BallInfo> workoutDetails;
}

//[System.Serializable]
public class WorkOut
{
    public int numberofWorkoutBalls;
    public List<WorkOutInfo> WorkOutInfos;
}

public enum ItemType
{
    Weapon,
    Armor,
    Consumable
}

class Item 
{
    public string Name;
    public ItemType Type;
}

class Player 
{
    public string Name;
    public int Health;
    public int2 Position;
    public Item[] Inventory;
}


/*
OUTPUT:
{
    "Name": "Bob",
    "Health": 100,
    "Position": {
        "x": 10,
        "y": 20
    },
    "Inventory": [
        {
            "Name": "Sword",
            "Type": 0
        },
        {
            "Name": "Shield"
            "Type": 1,
        },
        {
            "Name": "Health Potion"
            "Type": 2
        }
    ]
}
*/

public class SerializerManager : MonoBehaviour
{
    private readonly string fileName = "data.json";


    private void JsonReader()
    {
        string filePath = Path.Combine("Assets", fileName);
        // Debug.Log(filePath);

        if (!File.Exists(filePath))
        {
            Debug.LogWarning("File not Found!!");
            return;
        }

        string jsonData = File.ReadAllText(filePath);
        Debug.Log(jsonData);

        WorkOut json = JsonSerialization.FromJson<WorkOut>(jsonData);
        

        // int indexOfNumberOfWorkoutBalls = jsonData.IndexOf("\"numberOfWorkoutBalls\":");
        // int indexOfWorkOutInfo = jsonData.IndexOf("\"workoutInfo\":");

        // if (indexOfNumberOfWorkoutBalls < 0 || indexOfWorkOutInfo < 0)
        //  {
        //    Debug.LogError("Invalid JSON data format");
        //     return; // Handle invalid JSON format (optional)
        // }


        // Extract the value for "numberOfWorkoutBalls"
        // string numberOfWorkoutBallsString = jsonData.Substring(indexOfNumberOfWorkoutBalls + 22, jsonData.IndexOf(",", indexOfNumberOfWorkoutBalls) - indexOfNumberOfWorkoutBalls - 22);
        // int numberOfWorkoutBalls = int.Parse(numberOfWorkoutBallsString);

        // WorkOut info = JsonUtility.FromJson<WorkOut>(jsonData);
        // Debug.Log(info.WorkOutInfos.Count);

        /*
        if (info != null)
        {
            Debug.Log($"Number of Workout Balls: {info.numberofWorkoutBalls}");
            foreach (WorkOutInfo workout in info.WorkOutInfos)
            {
                Debug.Log($"Workout ID: {workout.workoutID}, Name: {workout.WorkoutName}");
                foreach (BallInfo detail in workout.workoutDetails)
                {
                    Debug.Log($"  Ball ID: {detail.ballId}, Speed: {detail.speed}, Direction: {detail.ballDirection}");
                }
            }
        }*/
        var player = new Player 
        {  
            Name = "Bob",  
            Health = 100,  
            Position = new int2(10, 20),  
            Inventory = new[]  
            {  
                new Item {Name = "Sword", Type = ItemType.Weapon},  
                new Item {Name = "Shield", Type = ItemType.Armor},  
                new Item {Name = "Health Potion", Type = ItemType.Consumable}  
            }  
        };
        
        
        var jsonstring = JsonSerialization.ToJson(player);
        Debug.Log(jsonstring);
        var deserializedPlayer = JsonSerialization.FromJson<Player>(jsonstring);
        Debug.Log(deserializedPlayer.Name);
        

    }

    private void Start()
    {
        JsonReader();
        
        
    }
    
    
}
