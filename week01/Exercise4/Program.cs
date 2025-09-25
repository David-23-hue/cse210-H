// Exercise4_Lists/Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> favoriteFoods = new List<string>();

        Console.WriteLine("Enter your 3 favorite foods:");

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Food #{i+1}: ");
            string food = Console.ReadLine();
            favoriteFoods.Add(food);
        }

        Console.WriteLine("\nYour favorite foods are:");
        foreach (string food in favoriteFoods)
        {
            Console.WriteLine(food);
        }
    }
}