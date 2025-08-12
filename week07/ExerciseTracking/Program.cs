using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes() => _minutes;
    public DateTime GetDate() => _date;

    public abstract double GetDistance(); // in miles
    public abstract double GetSpeed();    // in mph
    public abstract double GetPace();     // in min per mile

    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {this.GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

// Running class
public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / _distance;
}

// Cycling class
public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed() => _speed;
    public override double GetDistance() => (_speed * GetMinutes()) / 60;
    public override double GetPace() => 60 / _speed;
}

// Swimming class
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0 * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return GetDistance() / GetMinutes() * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
