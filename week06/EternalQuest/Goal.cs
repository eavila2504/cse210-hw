using System;

public abstract class Goal
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

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();
    public virtual string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description})";
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return int.Parse(_points);
    }
}