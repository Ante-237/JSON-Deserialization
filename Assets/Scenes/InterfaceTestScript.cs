using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceTestScript : MonoBehaviour
{
    void Start()
    {
        Nonagon one = new Nonagon(9, 5.4f);
        Circle two = new Circle(9);
        Trapezium three = new Trapezium(10, 15, 8);
        
        Debug.Log("Area of Nonagon :" + one.CalculateArea());
        Debug.Log("Perimeter of Nonagon :" + one.CalculatePerimeter());
        
        Debug.Log("Area of Circle :"+ two.CalculateArea());
        Debug.Log("Perimeter of Circle :" + two.CalculatePerimeter());
        
        Debug.Log("Area of Trapezium :" + three.CalculateArea());
        Debug.Log("Perimeter of Trapezium :" + three.CalculatePerimeter(10, 15, 8, 8));


    }

   
}