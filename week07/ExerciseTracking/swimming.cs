public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, double minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double meters = _laps * 50;
        double kilometers = meters / 1000.0;
        return kilometers * 0.621371; // meters → km → miles
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        return (distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? Minutes / distance : 0;
    }
}