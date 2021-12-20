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
        var (oxygenReading, co2Reading) = Day3.CalculateOxygenReadings(data);

        Console.WriteLine($"Day3.2: {oxygenReading * co2Reading}");
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

    [Fact]
    public void VerifyLifeSupport()
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

        var (oxygen, co2) = Day3.CalculateOxygenReadings(data);

        Assert.Equal(23, oxygen);
        Assert.Equal(10, co2);
        Assert.Equal(230, oxygen * co2);

    }
}
