using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        bool inhale = true;

        while (DateTime.Now < endTime)
        {
            if (inhale)
            {
                Console.WriteLine("Breathe in...");
                ShowCountdown(4);
            }
            else
            {
                Console.WriteLine("Breathe out...");
                ShowCountdown(6);
            }
            inhale = !inhale;
        }
    }
}