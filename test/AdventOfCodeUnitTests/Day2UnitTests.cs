using System.IO;
using System.Threading.Tasks;
using Xunit;
using AdventOfCode;
using System;

namespace AdventOfCodeUnitTests;

public class Day2UnitTests
{
    [Fact]
    public async Task Day1TestAsync()
    {
        var data = await File.ReadAllLinesAsync("day2-data.txt").ConfigureAwait(false);

        var (horizontalPosition, depth) = Day2.ProcessMovements(data);

        Console.WriteLine($"Day2.1: {horizontalPosition * depth}");

        var (horizontalPositionWithAim, depthWithAim) = Day2.ProcessMovementsWithAim(data);

        Console.WriteLine($"Day2.2: {horizontalPositionWithAim * depthWithAim}");
    }
}