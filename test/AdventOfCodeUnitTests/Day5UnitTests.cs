using System.IO;
using System.Threading.Tasks;
using Xunit;
using AdventOfCode;
using System;

namespace AdventOfCodeUnitTests;

public class Day5UnitTests
{
    [Fact]
    public async Task TestAsync()
    {
        var data = await File.ReadAllLinesAsync("day5-data.txt").ConfigureAwait(false);

        var numOverlappingPoints = Day5.ProcessInputFindOverlapping(data);

        Console.WriteLine($"Day5.1: {numOverlappingPoints}");
        var numOverlappingPointsWithDiagonals = Day5.ProcessInputFindOverlappingWithDiagonal(data);

        Console.WriteLine($"Day5.2: {numOverlappingPointsWithDiagonals}");
    }

    [Fact]
    public void VerifyVerticalAndHorizontal()
    {
        var data = new[]
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2",
        };
        var numOverlappingPoints = Day5.ProcessInputFindOverlapping(data);

        Assert.Equal(5, numOverlappingPoints);
    }

    [Fact]
    public void VerifyVerticalAndHorizontalAndDiagonal()
    {
        var data = new[]
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2",
        };
        var numOverlappingPoints = Day5.ProcessInputFindOverlappingWithDiagonal(data);

        Assert.Equal(12, numOverlappingPoints);
    }
}
