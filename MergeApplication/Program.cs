// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using MergeApplication;

if (!IsInputValid(args))
    return;

var mergedIntervals = MergeIntervals(args);
Console.WriteLine(string.Join(" ", mergedIntervals));

static List<Interval> MergeIntervals(string[] inputs)
{
    var mergedIntervals = new List<Interval>();
    foreach (var interval in inputs)
    {
        if (mergedIntervals.Count == 0)
        {
            mergedIntervals.Add(new Interval(interval));
            continue;
        }

        var intervalObject = new Interval(interval);
        var merged = false;
        foreach (var mergedInterval in mergedIntervals)
        {
            if (mergedInterval.Contains(intervalObject))
            {
                mergedInterval.Merge(intervalObject);
                merged = true;
                break;
            }
        }
        if(!merged)
            mergedIntervals.Add(intervalObject);
    }

    return mergedIntervals;
}

bool IsInputValid(string[] inputs)
{
    return inputs.All(x => Regex.IsMatch(x, @"\[-?[0-9]+,-?[0-9]+\]"));
}