using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        DisplayStartingMessage();
        SetDuration();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        PerformActivity();

        DisplayEndingMessage();
    }

    private void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    private void SetDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write($"\r{spinner[i % spinner.Count]}");
            Thread.Sleep(250);
            i++;
        }
        Console.Write("\r \r"); // Clear spinner
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}");
            Thread.Sleep(1000);
        }
        Console.Write("\r \r");
    }

    private void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    // Abstract method to be implemented by derived classes
    protected abstract void PerformActivity();
}