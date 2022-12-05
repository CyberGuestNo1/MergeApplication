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
    
    [Test] // No exception should be thrown
    public void TestManyInputs()
    {
        string[] args = { "[-17,79]", "[21,31]", "[-19,27]", "[76,97]", "[-11,48]", "[-47,59]", "[-21,88]", "[-95,71]", "[46,85]", "[50,99]", "[-75,4]", "[-79,-10]", "[-55,-4]", "[-76,79]", "[-93,20]", "[-8,88]", "[-72,77]", "[-83,27]", "[-24,66]", "[-26,23]", "[-23,14]", "[-22,80]", "[-96,-30]", "[-70,97]", "[80,86]", "[-10,-10]", "[-70,94]", "[-90,28]", "[-55,20]", "[-86,-47]", "[-93,79]", "[-33,6]", "[-72,15]", "[-47,30]", "[-13,37]", "[12,31]", "[-59,-29]", "[-99,38]", "[-2,-1]", "[-57,-56]", "[-12,83]", "[-55,37]", "[-64,1]", "[-82,-65]", "[85,98]", "[-30,72]", "[-8,48]", "[-14,77]", "[-94,-1]", "[41,53]", "[-56,66]", "[-63,-50]", "[14,57]", "[-60,-53]", "[-69,69]", "[43,83]", "[-75,-23]", "[-97,63]", "[-45,3]", "[-70,32]", "[-68,-12]", "[-57,-28]", "[-53,55]", "[-66,22]", "[-52,75]", "[-64,92]", "[-70,94]", "[-45,86]", "[22,24]", "[-26,59][10,18]", "[-33,60]", "[16,83]", "[-61,17]", "[-71,-23]", "[-90,-34]", "[-26,13]", "[-90,-31]", "[-81,17]", "[-86,79]", "[14,83]", "[-100,-21]", "[-50,66]", "[-75,-62]", "[-48,64]", "[-76,-35]", "[-34,87]", "[-50,-42]", "[47,92]", "[3,56]", "[13,70]", "[-88,-84]", "[-68,-34]", "[-16,55]", "[-77,7]", "[-5,46]", "[-88,-75]", "[-57,-22]", "[-74,-66]", "[-50,31]", "[-84,53]", "[-92,50]", "[59,77]", "[-88,-79]", "[17,52]", "[-32,7]", "[-18,-5]", "[19,30]", "[-23,8]", "[-22,-11]", "[-42,60]", "[-62,59]", "[-60,70]", "[-85,88]", "[-24,52]", "[-60,-50]", "[-73,-47]", "[67,79]", "[-20,57]", "[-30,74]", "[-28,-24]", "[-19,30]", "[64,83]", "[-78,9]", "[-25,80]", "[-89,-64]", "[-16,60]", "[30,79]", "[16,53]", "[-31,43]", "[21,88]", "[-64,-52]", "[2,77]", "[23,91]", "[-89,57]", "[-87,-49]", "[-41,-18]", "[-5,32]", "[-91,22]", "[-59,-15]", "[-54,63]", "[-68,6]", "[71,71]", "[-13,71]", "[-99,-47]", "[-93,93]", "[-75,13]", "[-88,54]", "[37,72]", "[65,83]", "[-97,-82]", "[-78,19]", "[25,95]", "[48,49]", "[-57,-29]", "[-83,-38]", "[-16,94]", "[14,82]", "[-12,99]", "[-99,-77]", "[-36,44]", "[-42,8]", "[-32,10]", "[-96,-33]", "[-77,11]", "[-64,78]", "[-71,-58]", "[-86,-39]", "[-46,90]", "[-58,72]", "[78,85]", "[-73,63]", "[-98,55]", "[-32,62]", "[-76,-50]", "[-34,40]", "[-18,65]", "[-2,73]", "[-46,-2]", "[-4,25]", "[75,77]", "[-91,60]", "[48,58]", "[63,97]", "[60,72]", "[-98,-87]", "[-46,54]", "[-57,53]", "[-63,96]", "[-27,-21]", "[-8,82]", "[-55,23]", "[-31,-27]", "[59,83]", "[-56,9]", "[-66,70]", "[6,21]", "[-12,73]", "[-45,13]", "[-91,43]", "[-69,-43]", "[-67,6]", "[0,77]", "[-33,19]", "[-10,10]", "[-33,-28]", "[-25,-16]", "[-28,11]", "[-75,89]", "[30,97]", "[17,45]", "[-11,38]", "[-46,22]", "[-81,-28]", "[-85,98]", "[-64,62]", "[-75,-43]", "[-77,-6]", "[-60,96]", "[-55,33]", "[37,42]", "[-62,-44]", "[67,76]", "[-10,24]", "[-66,74]", "[-46,67]", "[-43,-15]", "[-12,13]", "[31,89]", "[-96,34]", "[-80,66]", "[-77,-35]", "[-92,32]", "[-84,-57]", "[-21,76]", "[-45,23]", "[-56,-35]", "[10,82]", "[-4,53]", "[-96,78]", "[-56,-11]", "[51,60]", "[-18,51]", "[-23,45]", "[-92,47]", "[-59,61]", "[-55,65]", "[-98,23]", "[-96,-67]", "[-91,86]", "[-71,7]", "[-47,37]", "[-70,66]", "[25,57]", "[-59,22]", "[-76,26]", "[-31,-9]", "[-31,27]", "[-79,-12]", "[19,56]", "[-89,-88]", "[-42,2]", "[-83,46]", "[70,96]", "[-91,85]", "[24,94]", "[33,38]", "[8,51]", "[19,52]", "[71,88]", "[37,78]", "[29,99]", "[-44,86]", "[-14,-9]", "[8,41]", "[-83,-60]", "[41,72]", "[-63,-7]", "[-25,1]", "[-71,90]", "[-57,35]", "[10,22]", "[-67,-63]", "[45,52]", "[84,93]", "[-59,47]", "[-83,76]", "[62,94]", "[12,49]", "[-55,-49]", "[23,75]", "[-66,-31]", "[40,75]", "[36,65]", "[81,82]", "[-23,-11]", "[-8,66]", "[-37,22]", "[-65,80]", "[-44,81]", "[10,19]", "[-26,64]", "[89,99]", "[-53,-23]", "[-69,-9]", "[26,74]", "[-35,66]", "[-55,79]", "[23,75]", "[-64,-61]", "[-25,73]", "[-62,32]", "[-62,-58]", "[-90,-69]", "[-76,56]", "[54,73]", "[-57,60]", "[-79,-56]", "[-57,90]", "[11,13]", "[-29,-10]", "[-61,80]", "[13,22]", "[-86,12]", "[-93,-57]", "[67,95]", "[-27,-12]", "[-53,-20]", "[9,97]", "[-81,-14]", "[-71,-37]", "[-54,43]", "[57,58]", "[50,82]", "[-85,25]", "[1,36]", "[-100,-30]", "[-38,71]", "[-100,29]", "[-17,44]", "[-67,-35]", "[-43,23]", "[6,71]", "[-45,-16]", "[-37,-4]", "[-53,25]", "[-72,25]", "[-51,9]", "[-53,-17]", "[-63,90]", "[-17,35]", "[-24,20]", "[23,78]", "[-53,20]", "[-26,-10]", "[82,93]", "[-94,-72]", "[4,75]", "[-26,66]", "[-59,-6]", "[-82,47]", "[-35,50]", "[-41,32]", "[-61,-53]", "[-72,-52]", "[-63,-8]", "[0,14]", "[-47,93]", "[-93,-79]", "[81,87]", "[-83,-15]", "[-74,-67]", "[-8,11]", "[-78,-41]", "[34,65]", "[-4,71]", "[-48,-25]", "[57,88]", "[-9,25]", "[-15,26]", "[80,88]", "[26,62]", "[28,62]", "[-5,75]", "[-76,63]", "[-59,98]", "[-79,34]", "[-58,23]", "[-76,-53]", "[-32,25]", "[-12,15]", "[-98,26]", "[-66,22]", "[0,50]", "[-63,85]", "[1,90]", "[-32,49]", "[-63,11]", "[-52,-1]", "[27,73]", "[-55,85]", "[-98,94]", "[-55,-5]", "[-22,31]", "[-96,-93]", "[-60,6]", "[26,91]", "[42,45]", "[-94,75]", "[-59,-42]", "[25,79]", "[13,60]", "[-63,93]", "[-7,56]", "[60,98]", "[-44,93]", "[18,68]", "[-26,9]", "[-58,54]", "[-2,18]", "[58,65]", "[-5,-5]", "[-11,34]", "[-1,11]", "[-42,89]", "[-45,57]", "[-24,-23]", "[54,82]", "[51,63]", "[-94,11]", "[-71,37]", "[-99,89]", "[-53,-3]", "[-70,-58]", "[6,53]", "[-3,17]", "[71,93]", "[-57,13]", "[-96,84]", "[-40,51]", "[-80,88]", "[-37,52]", "[-81,-50]", "[16,35]", "[37,91]", "[31,65]", "[-64,70]", "[-42,32]", "[-60,64]", "[-88,-13]", "[-99,45]", "[69,94]", "[54,57]", "[-93,84]", "[29,38]", "[-54,52]", "[-24,-20]", "[3,90]", "[-29,-26]", "[2,92]", "[-91,-89]", "[-34,51]", "[-41,-26]", "[-66,2]", "[5,26]", "[-86,-8]", "[-87,-63]", "[-40,9]", "[24,74]", "[-26,-14]", "[-47,43]", "[5,40]", "[-82,-31]", "[-8,-4]", "[-42,59]", "[9,50]", "[2,50]", "[-87,29]", "[-47,6]", "[77,81]", "[-34,21]", "[-12,49]", "[-15,48]", "[4,11]", "[-69,66]", "[13,29]", "[-77,-38]", "[-17,51]", "[-35,78]", "[-98,61]", "[-47,-41]", "[29,60]", "[29,32]", "[-24,69][-44,16]", "[-19,23]", "[-27,24]", "[-63,13]", "[-97,-6]", "[-28,19]", "[-80,5]", "[-26,88]", "[-26,7]", "[-60,26]", "[8,39]", "[-42,-35]", "[-92,-18]", "[-45,7]", "[-12,4]", "[-99,41]", "[-79,-66]", "[-70,91]", "[-20,66]", "[-98,-31]", "[-2,89]", "[-5,25]", "[-49,82]", "[14,27]", "[-17,43]", "[-7,68]", "[-33,50]", "[13,20]", "[-81,-43]", "[6,64]", "[-77,69]", "[-47,34]", "[-39,68]", "[16,87]", "[17,80]", "[-69,96]", "[15,80]", "[-44,10]", "[-71,64]", "[39,48]", "[-70,-33]", "[-75,-65]", "[-87,-38]", "[-40,83]", "[49,55]", "[20,81]", "[8,43]", "[31,52]", "[-80,51]", "[-33,96]", "[-78,90]", "[-71,65]", "[-83,-10]", "[15,16]", "[-84,-45]", "[84,90]", "[66,68]", "[-73,-50]", "[85,86]", "[-60,57]", "[-99,-37]", "[-55,-52]", "[-15,64]", "[25,82]", "[-44,61]", "[35,62]", "[-66,13]", "[-58,64]", "[-35,91]", "[-83,40]", "[-47,86][-63,-45]", "[-54,-18]", "[-30,14]", "[39,63]", "[-43,46]", "[21,27]", "[8,10]", "[21,85]", "[-62,8]", "[-81,83]", "[-37,19]", "[-48,67]", "[-65,97]", "[-33,-23]", "[14,62]", "[-35,89]", "[-93,2]", "[-96,21]", "[76,92]", "[-71,37]", "[-98,2]", "[-58,8]", "[-6,52]", "[-60,-50]", "[-52,18]", "[-53,97]", "[64,65]", "[-100,-26]", "[18,62]", "[65,79]", "[-94,-33]", "[-91,56]", "[8,17]", "[8,30]", "[13,37]", "[-35,51]", "[-89,47]", "[-80,72]", "[-39,41]", "[-79,60]", "[-44,53]", "[-25,30]", "[-73,-45]", "[15,30]", "[48,69]", "[-32,31]", "[-37,22]", "[-7,13]", "[-92,78]", "[50,88]", "[-32,16]", "[-78,28]", "[-81,42]", "[-67,16]", "[-82,-4]", "[-100,-5]", "[74,76]", "[-91,-32]", "[-73,48]", "[-70,87]", "[12,18]", "[-31,-14]", "[-91,-51]", "[-97,6]", "[-67,12]", "[-95,12]", "[-53,77]", "[80,82]", "[21,38]", "[-16,56]", "[-99,24]", "[-71,90]", "[-92,18]", "[-73,82]", "[-96,65]", "[-70,-40]", "[-98,33]", "[-14,35]", "[-71,-34]", "[41,83]", "[-67,0]", "[-44,87]", "[-23,80]", "[-99,73]", "[63,97]", "[-82,25]", "[-88,-75]", "[-25,-18]", "[-90,9]", "[-90,76]", "[-71,-17]", "[-79,47]", "[-47,4]", "[-37,60]", "[-90,97]", "[24,46]", "[-28,81]", "[2,67]", "[49,95]", "[-15,43]", "[-95,30]", "[25,40]", "[15,97]", "[-92,-24]", "[-26,27]", "[51,89]", "[-90,70]", "[24,30]", "[27,29]", "[-64,-37]", "[15,67]", "[-73,74]", "[-37,16]", "[-44,-43]", "[-29,66]", "[34,58]", "[-98,54]", "[31,58]", "[1,29]", "[-59,-32]", "[-71,94]", "[15,77]", "[-78,41]", "[-48,10]", "[-49,12]", "[-50,26]", "[40,43]", "[-86,3]", "[-30,46]", "[-76,50]", "[-18,-13]", "[27,93]", "[1,99]", "[-85,35]", "[11,71]", "[10,74]", "[-63,78]", "[1,71]", "[-88,-88]", "[-63,-4]", "[-17,52]", "[-68,47]", "[-73,29]", "[-65,85]", "[3,33]", "[52,73]", "[-21,70]", "[33,70]", "[8,15]", "[-59,31]", "[-47,91]", "[13,87]", "[74,97]", "[-94,-57]", "[-7,93]", "[-48,-26]", "[42,67]", "[-85,85]", "[5,19]", "[27,69]", "[18,48]", "[75,78]", "[-82,81]", "[-24,82]", "[-77,51]", "[-30,54]", "[-16,89]", "[9,48]", "[-27,37]", "[-79,-1]", "[-40,43]", "[39,53]", "[46,74]", "[-35,58]", "[-38,85]", "[-89,-28]", "[-99,2]", "[-81,-57]", "[-54,60][-16,5]", "[-96,67]", "[38,39]", "[-73,-13]", "[76,94]", "[54,81]", "[-35,94]", "[-73,-9]", "[-20,66]", "[-54,63]", "[-43,8]", "[-95,-34]", "[-62,-17]", "[26,40]", "[-73,-17]", "[-39,33]", "[-46,-27]", "[-50,52]", "[-59,68]", "[-6,87]", "[-78,-63]", "[22,78]", "[-15,83]", "[83,87]", "[-20,90]", "[19,34]", "[-87,-79]", "[-57,93]", "[-99,84]", "[-29,71]", "[-15,40]", "[-20,-7]", "[4,51]", "[28,46]", "[69,90]", "[-44,57]", "[-77,-48]", "[-57,78]", "[-56,-33]", "[-1,76]", "[19,68]", "[-20,2]", "[-9,9]", "[-43,85]", "[-37,-6]", "[-32,98]", "[33,43]", "[-41,-25]", "[-7,22]", "[-80,58]", "[12,94]", "[13,53]", "[-27,38]", "[-91,57]", "[64,86]", "[2,14]", "[2,49]", "[-96,63]", "[20,95]", "[25,51]", "[-21,88]", "[27,33]", "[-45,-11]", "[-23,-15]", "[-64,48]", "[-23,91]", "[-64,-28]", "[-13,57]", "[-99,42]", "[-83,-81]", "[-56,52]", "[54,80]", "[-97,53]", "[-90,-78]", "[-77,71]", "[-52,87]", "[-22,-18]", "[-9,71]", "[-15,-9]", "[7,19]", "[12,15]", "[20,42]", "[-48,91]", "[-20,9]", "[-34,66]", "[27,57]", "[31,76]", "[-9,62]", "[-100,-61]", "[-7,-7]", "[60,76]", "[-46,-42]", "[-72,-6]", "[-95,32]", "[31,73]", "[-92,59]", "[-94,51]", "[-81,-50]", "[-82,-35]", "[-76,41]", "[20,76]", "[-47,87]", "[-69,80]", "[-35,34]", "[-70,64]", "[-72,82]", "[-9,72]", "[-3,2]", "[35,69]", "[68,79]", "[-34,-18]", "[-95,-12]", "[-67,-24]", "[-81,58]", "[-98,-49]", "[87,98]", "[-6,48]", "[-61,53]", "[-64,9]", "[4,31]", "[5,86]", "[-5,0]", "[-14,35]", "[-52,64]", "[-68,74]", "[-11,50]", "[-71,72]", "[25,79]", "[-67,13]", "[-63,26]", "[-64,-11]", "[-29,84]", "[-94,22]", "[-26,0]", "[-33,-10]", "[-98,-57]", "[-12,67]", "[1,64]", "[-56,49]", "[-81,-55]", "[-26,55]", "[26,95]", "[-1,43]", "[-85,46]", "[-69,91]", "[-50,96]", "[-91,-70]", "[-69,84]", "[-22,38]", "[69,83]", "[-16,50]", "[9,50]", "[-60,88]", "[-98,-2]", "[-9,-1]", "[-66,-25]", "[-24,96]", "[75,81]", "[-67,20]", "[-19,53]", "[42,95]", "[4,19]", "[-19,-11]", "[-41,72]", "[-24,-5]", "[19,52]", "[63,79]", "[-96,-20]", "[-92,-25]", "[-68,-43]", "[8,65]", "[30,83]", "[-50,89]", "[70,92]", "[-69,12]", "[-23,34]", "[-97,28]", "[-99,-30]", "[66,67]", "[73,74]", "[-44,21]", "[6,72]", "[-44,-11]", "[16,25]", "[-13,81]", "[19,59]", "[-64,14]", "[-51,59]", "[19,24]", "[-76,55]", "[67,91]", "[72,76]", "[47,81]", "[-31,96]", "[-51,66]", "[-29,7]", "[-87,-78]", "[-45,98]", "[-70,72]", "[-4,48]", "[57,65]", "[-78,18]", "[-53,13]", "[-71,-13]", "[7,62]", "[-73,29]", "[-13,60]", "[14,93]", "[-32,54]", "[54,98]", "[-30,-11]", "[-7,24]", "[-66,-46]", "[10,81]", "[-91,30]", "[-39,93]", "[-64,-38]", "[5,97]", "[-86,-13]", "[-59,36]", "[7,48]", "[-62,63]", "[55,59]", "[-65,16]", "[-92,-2]", "[-79,-19]", "[-95,81]", "[-69,-42]", "[-19,-15]", "[-61,71]", "[-88,31]", "[-95,36]", "[-19,19]", "[-78,70]", "[-6,28]", "[28,45]", "[-95,-19]", "[37,60]", "[-72,2]", "[-84,20]", "[-43,96]", "[-41,12]", "[63,93]", "[-70,25]", "[-39,8]", "[-78,-71]", "[1,29]", "[-74,-73]", "[-67,-61]", "[-94,-30]", "[-74,77]", "[-81,29]", "[-60,37]", "[-98,20]", "[-96,27]", "[-63,-28]", "[36,80]", "[-55,10]", "[-49,64]", "[-60,-59]" };
        Assert.DoesNotThrow(() => MergeApplication.Program.Main(args));
    }
    
    [Test] // No exception should be thrown
    public void TestBigInputNumbers()
    {
        string[] args = { "[6742624821430410978,9221325370589283605]", "[4121301197740302427,7037519826383631472]", "[3674212176085222972,6735876407149960154]" };
        Assert.DoesNotThrow(() => MergeApplication.Program.Main(args));
    }

    [Test]
    [TestCase(new object[] {"[10,20]", "[21,30]"}, new object[] {"[10,20]", "[21,30]"})] // no merge
    [TestCase(new object[] {"[10,20]", "[11,19]"}, new object[] {"[10,20]"})] // merge include
    [TestCase(new object[] {"[10,20]", "[11,25]"}, new object[] {"[10,25]"})] // merge increase end
    [TestCase(new object[] {"[10,20]", "[5,15]"}, new object[] {"[5,20]"})] // merge decrease start
    [TestCase(new object[] {"[10,20]", "[5,25]"}, new object[] {"[5,25]"})] // merge increase end and decrease start
    [TestCase(new object[] {"[10,20]", "[21,30]", "[1,40]"}, new object[] {"[1,40]"})] // merge two already added intervals
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