using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.WriteLine("You have a few seconds to think about your answer...");
        ShowCountdown(5);

        Console.WriteLine("Start listing! Press Enter after each item. Time starts now!");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> items = new List<string>();

        // Allow input until time runs out
        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    items.Add(input);
                }
            }
            else
            {
                Thread.Sleep(100); // Small delay to reduce CPU usage
            }
        }

        // Clear any remaining input
        while (Console.KeyAvailable)
        {
            Console.ReadKey(false);
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        Thread.Sleep(2000);
    }
}