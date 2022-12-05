using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MergeApplication;

public static class Program
{
    public static void Main(string[] args)
    {
        // if args contains any ? print help
        if (args.Any(x => x.Equals("?")))
        {
            PrintCommandLineHelp();
            return;
        }

        if (!IsInputValid(args))
            throw new ArgumentException("No interval given or at least one interval does not match the given scheme");

        var mergedIntervals = Merge(args);
        Console.WriteLine();
        Console.WriteLine(string.Join(" ", mergedIntervals));
    }

    private static List<Interval> Merge(string[] inputs)
    {
        var mergedIntervals = new List<Interval>();
        foreach (var interval in inputs)
        {
            var intervalObject = new Interval(interval);
            // check if interval can be merged with already existing intervals, else add to list
            var containingInterval = mergedIntervals.FindAll(x => x.Contains(intervalObject));
            if (containingInterval.Any())
            {
                var intervalsToMerge = new List<Interval> { intervalObject };
                intervalsToMerge.AddRange(containingInterval.Skip(1));
                // merge all containing intervals
                containingInterval.First().Merge(intervalsToMerge);
                
                // remove already added intervals that are now merged
                foreach (var mergedInterval in containingInterval.Skip(1))
                    mergedIntervals.Remove(mergedInterval);
            }
            else
                mergedIntervals.Add(intervalObject);
        }
        return mergedIntervals;
    }

    private static bool IsInputValid(string[] inputs)
    {
        // check if all inputs are like [-19,360]
        return inputs.Length != 0 && inputs.All(x => Regex.IsMatch(x, @"\[-?[0-9]+,-?[0-9]+\]"));
    }
    
    private static void PrintCommandLineHelp()
    {
        Console.WriteLine("MergeApplication Interval1 [IntervalN] [IntervalN]...");
        Console.WriteLine();
        Console.WriteLine($"Interval1          The first interval given to the program to merge.");
        Console.WriteLine($"IntervalN          Additional Intervals given to the program to merge.");
    }
}