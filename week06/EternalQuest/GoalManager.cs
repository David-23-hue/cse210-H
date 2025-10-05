using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private List<string> _badges = new List<string>();

    public void Start()
    {
        LoadGoals();
        DisplayWelcome();

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("\nMENU:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); Console.WriteLine("Goals saved successfully."); break;
                case "5": quit = true; Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid choice. Please try again."); break;
            }
        }
    }

    private void DisplayWelcome()
    {
        Console.WriteLine("\n🌟 Welcome to the Eternal Quest Program! 🌟");
        Console.WriteLine($"Current Score: {_score} | Level: {_level}");
        if (_badges.Count > 0)
            Console.WriteLine($"Badges: {string.Join(", ", _badges)}");
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            bool wasComplete = goal.IsComplete();
            goal.RecordEvent();
            bool nowComplete = goal.IsComplete();

            // Award base points
            _score += goal.GetPoints();
            Console.WriteLine($"Congratulations! You earned {goal.GetPoints()} points!");

            // Handle bonus for checklist goals
            if (goal is ChecklistGoal checklist)
            {
                if (!wasComplete && nowComplete)
                {
                    _score += checklist.GetBonus();
                    Console.WriteLine($"Bonus! You earned an additional {checklist.GetBonus()} points for completing the checklist!");
                }
            }

            // Level up logic (exceeds requirements)
            int newLevel = (_score / 1000) + 1;
            if (newLevel > _level)
            {
                _level = newLevel;
                string badge = $"Level {_level} Achiever";
                _badges.Add(badge);
                Console.WriteLine($"\n🔥 LEVEL UP! You reached Level {_level}! 🔥");
                Console.WriteLine($"🎖️  New Badge Earned: {badge}");
            }

            Console.WriteLine($"Total Score: {_score}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_level);
            writer.WriteLine(string.Join("|", _badges));

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        if (!File.Exists("goals.txt")) return;

        string[] lines = File.ReadAllLines("goals.txt");
        if (lines.Length == 0) return;

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);
        if (lines.Length > 2 && !string.IsNullOrEmpty(lines[2]))
        {
            _badges = new List<string>(lines[2].Split('|'));
        }

        for (int i = 3; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(
                    parts[1], 
                    parts[2], 
                    int.Parse(parts[3]), 
                    int.Parse(parts[4]), 
                    int.Parse(parts[5]), 
                    int.Parse(parts[6])
                ));
            }
        }
    }
}