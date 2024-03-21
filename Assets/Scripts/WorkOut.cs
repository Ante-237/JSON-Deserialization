using System.Collections.Generic;

[System.Serializable]
public class WorkOut
{
    public int numberOfWorkoutBalls;
    public List<WorkoutInfo> workoutInfo;
    
    
}

[System.Serializable]
public class WorkoutInfo
{
    public int workoutID;
    public string workoutName;
    public string description;
    public string ballType;
    public List<WorkoutDetails> workoutDetails;
}

[System.Serializable]
public class WorkoutDetails
{
    public int ballId;
    public float speed;
    public float ballDirection;
}