using System.IO;
using System.Threading.Tasks;
using Xunit;
using AdventOfCode;
using System;

namespace AdventOfCodeUnitTests;

public class Day3UnitTests
{
    [Fact]
    public async Task TestAsync()
    {
        var data = await File.ReadAllLinesAsync("day3-data.txt").ConfigureAwait(false);

        var (gamma, epsilon) = Day3.ProcessReadings(data);

        Console.WriteLine($"Day3.1: {gamma * epsilon}");
        // var (horizontalPositionWithAim, depthWithAim) = Day2.ProcessMovementsWithAim(data);

        // Console.WriteLine($"Day2.2: {horizontalPositionWithAim * depthWithAim}");
    }

    [Fact]
    public void VerifyMostCommon()
    {
        var data = new string[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        var (gamma, epsilon) = Day3.ProcessReadings(data);

        Assert.Equal(22, gamma);
        Assert.Equal(9, epsilon);
        Assert.Equal(198, gamma * epsilon);
    }
}
