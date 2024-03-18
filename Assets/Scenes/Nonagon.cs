using System;
using UnityEngine;

public class Nonagon : IShape
{
    private int numberOfSides;
    private double lengthOfsides;

    public Nonagon(int numberOfSides,double lengthOfsides)
    {
        this.numberOfSides = numberOfSides;
        this.lengthOfsides = lengthOfsides;
    }
    
    public double CalculateArea()
    {
        if (numberOfSides <= 0)
        {
            Debug.Log("Wrong number of Sides");
            return default;
        }
        
        double apothem = lengthOfsides / (2 * Mathf.Tan(Mathf.PI / 9));
        double area = (9 * lengthOfsides * apothem) / 2;

        return area;
    }

    public double CalculatePerimeter()
    {
        if (lengthOfsides <= 0)
        {
            Debug.Log("Wrong number of sides");
            return default;
        }

        return (9 * lengthOfsides);
    }

    public int CalculateNumberOfSides()
    {
        
        return numberOfSides;
    }
}