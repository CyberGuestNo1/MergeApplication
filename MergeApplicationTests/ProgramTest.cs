using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace MergeApplicationTests;

[TestFixture]
public class ProgramTests
{
    [Test] // No exception should be thrown
    public void TestValidationFormatPositive()
    {
        string[] args = { "[1,2]", "[3,4]", "[5,6]", "[7,8]", "[9,10]", "[11,12]", "[13,14]" };
        Assert.DoesNotThrow(() => MergeApplication.Program.Main(args));
    }
    
    [Test] // Argument Exception should be thrown
    [TestCase(new object[] {""})]
    [TestCase(new object[] {"1,2]"})]
    [TestCase(new object[] {"[,2]"})]
    [TestCase(new object[] {"[12]"})]
    [TestCase(new object[] {"[1,]"})]
    [TestCase(new object[] {"[1,2"})]
    public void TestValidationFormatNegative(object[] objectArgs)
    {
        // convert object array to string array. TestCase does not support arrays of type string
        string[] args = Array.ConvertAll(objectArgs, x => x.ToString())!;
        
        Assert.Throws<ArgumentException>(() => MergeApplication.Program.Main(args));
    }

    [Test]
    [TestCase(new object[] {"[10,20]", "[21,30]"}, new object[] {"[10,20]", "[21,30]"})] // no merge
    [TestCase(new object[] {"[10,20]", "[11,19]"}, new object[] {"[10,20]"})] // merge include
    [TestCase(new object[] {"[10,20]", "[11,25]"}, new object[] {"[10,25]"})] // merge increase end
    [TestCase(new object[] {"[10,20]", "[5,15]"}, new object[] {"[5,20]"})] // merge decrease start
    [TestCase(new object[] {"[10,20]", "[5,25]"}, new object[] {"[5,25]"})] // merge increase end and decrease start
    public void TestMerge(object[] objectArgs, object[] objectOutput)
    {
        // convert object arrays to string arrays. TestCase does not support arrays of type string
        string[] args = Array.ConvertAll(objectArgs, x => x.ToString())!;
        string[] output = Array.ConvertAll(objectOutput, x => x.ToString())!;
        
        // prepare expected console output
        var intervalOutputs = new List<MergeApplication.Interval>();
        foreach (var interval in output)
            intervalOutputs.Add(new MergeApplication.Interval(interval));
        
        var console = string.Join(" ", intervalOutputs);

        // redirect console to assert later
        var writer = new StringWriter();
        Console.SetOut(writer);
        
        MergeApplication.Program.Main(args);
        
        // get console of program
        var sb = writer.GetStringBuilder();
        Assert.AreEqual(console, sb.ToString().Trim());
    }
}