using System;

public abstract class Activity
{
    private DateTime _date;
    private double _minutes;

    public Activity(DateTime date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Protected properties so derived classes can read these values
    protected DateTime Date => _date;
    protected double Minutes => _minutes;

    // Abstract methods — must be overridden
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Virtual GetSummary that uses polymorphism (NOT overridden in derived classes)
    public virtual string GetSummary()
    {
        string activityName = GetType().Name;
        string formattedDate = _date.ToString("dd MMM yyyy");
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{formattedDate} {activityName} ({_minutes:F1} min) - Distance {distance:F1} miles, Speed {speed:F1} mph, Pace: {pace:F1} min per mile";
    }
}