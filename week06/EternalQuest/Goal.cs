using System;

public class Goal
{
    private string _name;
    private string _description;
    private string _points;

    public Goal(string name, string description, string points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public void RecordEvent();
    {
        return _name
    }

    public bool IsComplete()
    {
        return false;
    }

    public string GetDetailString()
    {
        return _description;
    }

    public string GetStringRepresentation()
    {
        return _points;
    }
}