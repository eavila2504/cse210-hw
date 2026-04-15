using System;

public class Cycling : Activity
{
    private double _speed; //per kilometers

    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;

    }

    public Cycling(int minutes, double speed) : base(minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (GetDuration() / 60.0) * _speed;
        
    }
    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return  GetDuration() / GetDistance();  
    }
} 