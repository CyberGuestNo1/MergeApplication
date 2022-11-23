using System.Text.RegularExpressions;

namespace MergeApplication;

public class Interval
{
    private long _start;
    private long _end;

    public Interval(string interval)
    {
        var digits = new List<long>();
        foreach (Match digit in Regex.Matches(interval, "-?[0-9]+"))
            digits.Add(long.Parse(digit.Value));
        
        digits.Sort();
        _start = digits[0];
        _end = digits[1];
    }

    public bool Contains(Interval interval)
    {
        return interval._start >= _start && interval._start <= _end || interval._end <= _end && interval._end >= _start ||
               interval._start <= _start && interval._end >= _end;
    }

    public void Merge(Interval interval)
    {
        if (interval._start < _start)
            _start = interval._start;
        if (interval._end > _end)
            _end = interval._end;
    }

    public override string ToString()
    {
        return $"[{_start},{_end}]";
    }
}