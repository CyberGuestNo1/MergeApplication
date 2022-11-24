using System.Text.RegularExpressions;

namespace MergeApplication;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Any(x => x.Equals("?")))
        {
            PrintCommandLineDocs();
            return;
        }

        if (!IsInputValid(args))
            throw new ArgumentException("No interval given or at least one interval does not match the given scheme");

        var mergedIntervals = MergeIntervals(args);
        Console.WriteLine(string.Join(" ", mergedIntervals));
    }

    private static List<Interval> MergeIntervals(string[] inputs)
    {
        var mergedIntervals = new List<Interval>();
        foreach (var interval in inputs)
        {
            // for first interval no merge is needed
            if (mergedIntervals.Count == 0)
            {
                mergedIntervals.Add(new Interval(interval));
                continue;
            }

            var intervalObject = new Interval(interval);
            // check if interval can be merged with already existing interval, else add to list
            var containingInterval = mergedIntervals.FirstOrDefault(x => x.Contains(intervalObject));
            if(containingInterval != null)
                containingInterval.Merge(intervalObject);
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
    
    private static void PrintCommandLineDocs()
    {
        Console.WriteLine("MergeApplication Interval1 [IntervalN] [IntervalN]...");
        Console.WriteLine();
        Console.WriteLine($"Interval1          The first interval given to the program to merge.");
        Console.WriteLine($"IntervalN          Additional Intervals given to the program to merge.");
    }
}