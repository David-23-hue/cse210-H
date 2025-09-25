// Exercise5_Functions/Program.cs
using System;

class Program
{
    // Function to add two numbers
    static double Add(double a, double b)
    {
        return a + b;
    }

    static void Main()
    {
        Console.Write("Enter the first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double num2 = double.Parse(Console.ReadLine());

        double result = Add(num1, num2);
        Console.WriteLine($"The sum of {num1} and {num2} is: {result}");
    }
}