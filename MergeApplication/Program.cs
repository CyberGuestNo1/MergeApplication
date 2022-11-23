using System.Text.RegularExpressions;

namespace MergeApplication;

public static class Program
{
    public static void Main(string[] args)
    {
        if (!IsInputValid(args))
            throw new ArgumentException("At least one does not match the given scheme.");

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
            // check if interval can be merged with already existing interval. Else add to list
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
        return inputs.All(x => Regex.IsMatch(x, @"\[-?[0-9]+,-?[0-9]+\]"));
    }
}