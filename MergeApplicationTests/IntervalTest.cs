using System.Collections.Generic;
using MergeApplication;
using NUnit.Framework;

namespace MergeApplicationTests;

[TestFixture]
public class IntervalTest
{
    [Test]
    [TestCase("[1,10]")] // normal
    [TestCase("[-1,10]")] // negative start
    [TestCase("[-10,-1]")] // negative end
    [TestCase("[10,1]")] // wrong order
    public void TestConstructor(string arg)
    {
        var interval = new Interval(arg);
        Assert.NotNull(interval);
    }
    
    [Test]
    [TestCase("[10,20]", "[21,30]", false)] // does not contain
    [TestCase("[10,20]", "[11,19]", true)] // first contains second
    [TestCase("[10,20]", "[11,25]", true)] // first contains second partially
    [TestCase("[10,20]", "[5,15]", true)] // first contains second partially
    [TestCase("[10,20]", "[5,25]", true)] // second contains first
    public void TestContains(string firstInterval, string secondInterval, bool result)
    {
        var first = new Interval(firstInterval);
        var second = new Interval(secondInterval);
        Assert.AreEqual(result, first.Contains(second));
    }

    [Test]
    [TestCase("[10,20]", "[11,19]", 10, 20)] // first includes second
    [TestCase("[10,20]", "[11,25]", 10, 25)] // first includes second. first end increased to 25
    [TestCase("[10,20]", "[5,15]", 5, 20)] // first includes second. first start decreased to 5
    [TestCase("[10,20]", "[5,25]", 5, 25)] // second includes first
    public void TestMerge(string firstInterval, string secondInterval, long start, long end)
    {
        var first = new Interval(firstInterval);
        var second = new Interval(secondInterval);
        first.Merge(new List<Interval> { second });
        Assert.AreEqual(start, first.Start);
        Assert.AreEqual(end, first.End);
    }
    
    [Test] // input string is equal to output string
    public void TestToString()
    {
        var intervalString = "[10,20]";
        var first = new Interval(intervalString);
        Assert.AreEqual(intervalString, first.ToString());
    }
}