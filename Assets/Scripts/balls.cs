using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class balls : MonoBehaviour
{
    public int BallId;

    public Rigidbody rb;
    
    public void MoveObject(float BallDirection, float BallSpeed)
    {
        rb.AddForce(new Vector3(BallDirection, 0, 0) * BallSpeed, ForceMode.Acceleration);
    }
}
