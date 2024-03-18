using System;
using UnityEngine;

public class Circle : IShape
{
    private float radius;

    public Circle(float radius)
    {
        this.radius = radius;
    }
    
    public double CalculateArea()
    {
        if (radius <= 0)
        {
            Debug.Log("Radius is invalid");
            return default;
        }

        return (Mathf.PI * Mathf.Pow(radius, 2));
    }

    public double CalculateRadius(float area)
    {
        Debug.Log("Calculating Radius using Area");
        return Mathf.Sqrt(area / Mathf.PI);
    }

    public double CalculatePerimeter()
    {
        if (radius <= 0)
        {
            Debug.Log("Invalid Radius");
            return default;
        }

        return 2 * Mathf.PI * radius;
    }
}