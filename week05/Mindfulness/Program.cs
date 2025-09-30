// W05 Mindfulness Program
// Author: [Your Name]
// 
// Creative Enhancement:
// - Added session tracking: counts how many times each activity is performed.
// - At program exit, displays a summary of total sessions completed.
// - Ensures the user sees their progress, encouraging continued mindfulness practice.

using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Session counters for exceeding requirements
        int breathingCount = 0;
        int reflectionCount = 0;
        int listingCount = 0;

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    breathingCount++;
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    reflectionCount++;
                    break;
                case "3":
                    activity = new ListingActivity();
                    listingCount++;
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    continue;
            }

            if (activity != null)
            {
                activity.Start();
            }
        }

        // Display session summary (creative enhancement)
        Console.Clear();
        Console.WriteLine("Session Summary");
        Console.WriteLine("----------------");
        Console.WriteLine($"Breathing Activities: {breathingCount}");
        Console.WriteLine($"Reflection Activities: {reflectionCount}");
        Console.WriteLine($"Listing Activities: {listingCount}");
        Console.WriteLine("Thank you for practicing mindfulness today!");
        Thread.Sleep(3000);
    }
}