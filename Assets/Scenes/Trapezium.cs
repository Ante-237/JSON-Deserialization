

using UnityEngine;

public class Trapezium : IShape
{
    private double UpBase;
    private double DownBase;
    private double height;

    public Trapezium(double UpBase, double DownBase, double height)
    {
        this.UpBase = UpBase;
        this.DownBase = DownBase;
        this.height = height;
    }
    
    public double CalculateUnknownSides(double Base2, double height, double area)
    {
        Debug.Log("Unknown side Base 1");
        return (2 * area) / (Base2 * Mathf.Pow((float)height, 2));
    }

    public double CalculateArea()
    {
        if (UpBase <= 0 || DownBase <= 0 || height <= 0)
        {
            Debug.Log("Invalid Base or Height");
            return default;
        }

        return 0.5 * height * (DownBase + UpBase);
    }

    public double CalculatePerimeter(double base1, double base2, double leg1, double leg2)
    {
        if (base1 <= 0 || base2 <= 0 || leg1 <= 0 || leg2 <= 0)
        {
            Debug.Log("Invalid Sides");
        }

        double perimeter = base1 + base2 + leg1 + leg2;

        return perimeter;
    }
}