public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, double minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * Minutes) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? Minutes / distance : 0;
    }
}