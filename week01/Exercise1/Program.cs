// Exercise1_VariablesInputOutput/Program.cs
using System;

class Program
{
    static void Main()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        Console.Write("How old are you? ");
        string ageInput = Console.ReadLine();
        int age = int.Parse(ageInput);

        Console.WriteLine($"Hello, {name}! You are {age} years old.");
    }
}  