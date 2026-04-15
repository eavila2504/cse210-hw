public class Swimming : Activity
{
    private int _laps;
    private const double LapDistance = 50.0 / 1000 * 0.62;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public Swimming(int minutes, int laps) : base(minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LapDistance;

    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetDuration()) * 60;
    }

    public override double GetPace()
    {
        return GetDuration() / GetDistance();
    }
}
