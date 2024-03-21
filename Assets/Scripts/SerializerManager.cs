using System;
using System.IO;
using System.Text.Json;
using Palmmedia.ReportGenerator.Core.Common;
using TMPro;
using Unity.Mathematics;
using Unity.Serialization.Json;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SerializerManager : MonoBehaviour
{
    public JsonDeserialization JD;
    public Button ButtonPrefab;
    public Transform ParentObject;
    public GameObject BallPrefab;
    public int ScaleFactor = 4;

    private WorkOut Data;


    private int NumberOfButtons;
    private int NumberOfBalls;
    private void Start()
    {
       Data = JD.JsonReader();

       NumberOfButtons = Data.workoutInfo.Count;
       NumberOfBalls = Data.numberOfWorkoutBalls;

       for (int i = 0; i < NumberOfButtons; i++)
       {
           Button CurrentButton = Instantiate(ButtonPrefab, Vector3.zero, Quaternion.identity, ParentObject.transform);
           TextMeshProUGUI TextComponent = CurrentButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
           TextComponent.text = Data.workoutInfo[i].workoutName;
           TextComponent.text += "\n" + "<size=10>" + Data.workoutInfo[i].description + "</size>";
           if (Data.workoutInfo[i].ballType == "rolling ball")
           {
               CurrentButton.onClick.AddListener(RollingBall);
           }else if (Data.workoutInfo[i].ballType == "bouncing ball")
           {
               CurrentButton.onClick.AddListener(BouncingBalling);
           }else if (Data.workoutInfo[i].ballType == "linedrive ball")
           {
               CurrentButton.onClick.AddListener(LineDriveBall);
           }else if (Data.workoutInfo[i].ballType == "pop-up ball")
           {
               CurrentButton.onClick.AddListener(PopUpBall);
           }
       }
    }
    

    public void RollingBall()
    {
        for (int j = 0; j < Data.workoutInfo.Count; j++)
        {
            if (Data.workoutInfo[j].ballType == "rolling ball")
            {
                for (int i = 0; i < NumberOfBalls; i++)
                {
                    GameObject obj = Instantiate(BallPrefab, new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z) * ScaleFactor, Quaternion.identity);
                    obj.name = "rolling ball";
                    balls b = obj.GetComponent<balls>();
                    b.BallId = Data.workoutInfo[j].workoutDetails[i].ballId;
                    b.MoveObject(Data.workoutInfo[j].workoutDetails[i].ballDirection, Data.workoutInfo[j].workoutDetails[i].speed);
                }
            }
        }
        
       
    }

    public void BouncingBalling()
    {
        for (int j = 0; j < Data.workoutInfo.Count; j++)
        {
            if (Data.workoutInfo[j].ballType == "bouncing ball")
            {
                for (int i = 0; i < NumberOfBalls; i++)
                {
                    GameObject obj = Instantiate(BallPrefab, new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z) * ScaleFactor, Quaternion.identity);
                    obj.name = "bouncing ball";
                    balls b = obj.GetComponent<balls>();
                    b.BallId = Data.workoutInfo[j].workoutDetails[i].ballId;
                    b.MoveObject(Data.workoutInfo[j].workoutDetails[i].ballDirection, Data.workoutInfo[j].workoutDetails[i].speed);
                }
            }
        }
    }

    public void LineDriveBall()
    {
        for (int j = 0; j < Data.workoutInfo.Count; j++)
        {
            if (Data.workoutInfo[j].ballType == "linedrive ball")
            {
                for (int i = 0; i < NumberOfBalls; i++)
                {
                    GameObject obj = Instantiate(BallPrefab,new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z) * ScaleFactor, Quaternion.identity);
                    obj.name = "linedrive ball";
                    balls b = obj.GetComponent<balls>();
                    b.BallId = Data.workoutInfo[j].workoutDetails[i].ballId;
                    b.MoveObject(Data.workoutInfo[j].workoutDetails[i].ballDirection, Data.workoutInfo[j].workoutDetails[i].speed);
                }
            }
        }
    }

    public void PopUpBall()
    {
        for (int j = 0; j < Data.workoutInfo.Count; j++)
        {
            if (Data.workoutInfo[j].ballType == "pop-up ball")
            {
                for (int i = 0; i < NumberOfBalls; i++)
                {
                    GameObject obj = Instantiate(BallPrefab, new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z) * ScaleFactor, Quaternion.identity);
                    obj.name = "pop-up ball";
                    balls b = obj.GetComponent<balls>();
                    b.BallId = Data.workoutInfo[j].workoutDetails[i].ballId;
                    b.MoveObject(Data.workoutInfo[j].workoutDetails[i].ballDirection, Data.workoutInfo[j].workoutDetails[i].speed);
                }
            }
        }
    }
    
}
