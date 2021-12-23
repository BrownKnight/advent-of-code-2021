using System.IO;
using System.Threading.Tasks;
using Xunit;
using AdventOfCode;
using System;

namespace AdventOfCodeUnitTests;

public class Day1UnitTests
{
    [Fact]
    public async Task Day1TestAsync()
    {
        var data = await File.ReadAllLinesAsync("day1-data.txt").ConfigureAwait(false);

        var (numIncreased, numDecreased) = Day1.CountChanges(data);

        Console.WriteLine(numIncreased);

        var numIncreasedWithWindow = Day1.CountChangesWithWindow(data, 3);
        Console.WriteLine($"IncreasesWithWindowSize: {numIncreasedWithWindow}");
    }

    [Fact]
    public void VerifyNumIncreaseAndDecrease()
    {
        var data = new string[] { "1", "2", "3", "2", "1" };
        var (expectedIncrease, expectedDecrease) = (2, 2);

        var (numIncreased, numDecreased) = Day1.CountChanges(data);

        Assert.Equal(expectedIncrease, numIncreased);
        Assert.Equal(expectedDecrease, numDecreased);
    }

    [Fact]
    public void VerifyNumIncreasesWithWindow()
    {
        var data = new string[]
        {
            "199",
            "200",
            "208",
            "210",
            "200",
            "207",
            "240",
            "269",
            "260",
            "263"
        };
        var expectedIncrease = 5;
        var numIncreased = Day1.CountChangesWithWindow(data, 3);

        Assert.Equal(expectedIncrease, numIncreased);
    }
}