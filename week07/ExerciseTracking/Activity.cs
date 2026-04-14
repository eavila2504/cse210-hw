using System;
using System.Collections.Generic;

public class Activity
{
    private string _date;
    private int _duration; // minutes

    public Activity(string date, int minutes)
    {
        _date = date;
        _duration = minutes;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public virtual double GetDistance()
    {
        return 0.0;
    }

    public virtual double GetSpeed()
    {
        return 0.0;
    }

    public virtual double GetPace()
    {
        return 0.0;
    }
     
    public virtual string GetSummary()
    {
        return $"{GetDate()} {GetType().Name} ({GetDuration()} min): Distance{GetDistance()} km, Speed{GetSpeed()} kph, Pace: {GetPace()} min per km";
        
    }

}