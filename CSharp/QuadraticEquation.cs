﻿/*
    Implement the function FindRoots to find the roots of the quadratic equation: ax^2 + bx + c = 0.

    The roots of the quadratic equation can be found with the following formula: A quadratic equation.

    For example, the roots of the equation 2x2 + 10x + 8 = 0 are -1 and -4.
 */

using System;

public class QuadraticEquation
{
    public static Tuple<double, double> FindRoots(double a, double b, double c)
    {
 
        var sqrtPart = b * b - 4 * a * c; 

        var x1 = (-b + Math.Sqrt(sqrtPart)) / (2 * a); 
        var x2 = (-b - Math.Sqrt(sqrtPart)) / (2 * a); 
        var roots = new Tuple<double, double>(x1, x2);
        return roots;
    }

    public static void Main(string[] args)
    {
        var roots = FindRoots(2, 10, 8);
        Console.WriteLine("Roots: " + roots.Item1 + ", " + roots.Item2);

        Console.ReadKey();
    }
}