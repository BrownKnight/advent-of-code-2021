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
        //var lastWinningBoardScore = Day4.ProcessInputForFinalWinningBoard(data);

        //Console.WriteLine($"Day4.2: {lastWinningBoardScore}");
    }

    [Fact]
    public void Verify()
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

        Assert.Equal(2, numOverlappingPoints);
    }
}
