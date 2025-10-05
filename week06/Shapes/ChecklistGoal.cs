public class ChecklistGoal : Goal
{
    private int _target;
    private int _completed;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _target = target;
        _completed = 0;
        _bonus = bonus;
    }

    // Constructor for loading
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int completed) 
        : base(name, description, points)
    {
        _target = target;
        _completed = completed;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_completed < _target)
        {
            _completed++;
        }
    }

    public override bool IsComplete() => _completed >= _target;

    public override string GetDetailsString()
    {
        string status = _completed >= _target ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) -- Currently completed {_completed}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_target}|{_bonus}|{_completed}";
    }

    public int GetBonus() => _bonus;
    public int GetCompleted() => _completed;
    public int GetTarget() => _target;
}