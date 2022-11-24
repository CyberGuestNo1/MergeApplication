using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MergeApplication;

public class Interval
{
    public long Start;
    public long End;

    /// <summary>
    /// Create a new Interval object
    /// </summary>
    /// <param name="interval">The string of interval with two digits. E.g. '[-1,15]'</param>
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

    /// <summary>
    /// Check if parameter interval overlaps with current interval
    /// </summary>
    /// <param name="interval">The interval to check with current interval</param>
    /// <returns>A boolean</returns>
    public bool Contains(Interval interval)
    {
        // check start is between start and end of current interval OR end is between start and end of current interval OR
        return interval.Start >= Start && interval.Start <= End || interval.End <= End && interval.End >= Start ||
               // start and end of current interval is between start and end of parameter interval
               interval.Start <= Start && interval.End >= End;
    }

    /// <summary>
    /// Merge the current interval with the parameter interval
    /// </summary>
    /// <param name="interval">The interval that should be merged with the current interval</param>
    public void Merge(Interval interval)
    {
        if (interval.Start < Start)
            Start = interval.Start;
        if (interval.End > End)
            End = interval.End;
    }

    /// <summary>
    /// Convert the current Interval to string. E.g. '[-1,15]'
    /// </summary>
    /// <returns>A string</returns>
    public override string ToString()
    {
        return $"[{Start},{End}]";
    }
}