using System.Text.RegularExpressions;

namespace MergeApplication;

public class Interval
{
    public long Start;
    public long End;

    public Interval(string interval)
    {
        // get numbers out of input string
        var digits = new List<long>();
        foreach (Match digit in Regex.Matches(interval, "-?[0-9]+"))
            digits.Add(long.Parse(digit.Value));
        
        // sort list if numbers are in wrong order
        digits.Sort();
        Start = digits[0];
        End = digits[1];
    }

    public bool Contains(Interval interval)
    {
        // check start is between start and end of current interval OR end is between start and end of current interval OR
        return interval.Start >= Start && interval.Start <= End || interval.End <= End && interval.End >= Start ||
               // start and end of current interval is between start and end of parameter interval
               interval.Start <= Start && interval.End >= End;
    }

    public void Merge(Interval interval)
    {
        if (interval.Start < Start)
            Start = interval.Start;
        if (interval.End > End)
            End = interval.End;
    }

    public override string ToString()
    {
        return $"[{Start},{End}]";
    }
}