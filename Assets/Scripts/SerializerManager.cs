using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Palmmedia.ReportGenerator.Core.Common;
using UnityEngine;

[System.Serializable]
public class BallInfo
{
    public int ballId;
    public float speed;
    public float ballDirection;
}

[System.Serializable]
public class WorkOutInfo
{
    public int workoutID;
    public string WorkoutName;
    public string description;
    public string ballType;
    public List<BallInfo> workoutDetails;
}

[System.Serializable]
public class WorkOut
{
    public int numberofWorkoutBalls;
    public List<WorkOutInfo> WorkOutInfos;
}


public class SerializerManager : MonoBehaviour
{
    private readonly string fileName = "data.json";


    private void JsonReader()
    {
        string filePath = Path.Combine("Assets", fileName);
        Debug.Log(filePath);

        if (!File.Exists(filePath))
        {
            Debug.LogWarning("File not Found!!");
            return;
        }

        string jsonData = File.ReadAllText(filePath);
        Debug.Log(jsonData);
        
        WorkOut info = JsonUtility.FromJson<WorkOut>(jsonData);
        Debug.Log(info.WorkOutInfos.Count);

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
        }
        



    }

    private void Start()
    {
        JsonReader();
    }
}
