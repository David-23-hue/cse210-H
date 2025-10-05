public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals never complete; just acknowledge
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return "[∞] " + _name + " (" + _description + ")";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }
}