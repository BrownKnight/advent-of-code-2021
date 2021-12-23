using System;
namespace AdventOfCode;

public class Day5
{
    public static int ProcessInputFindOverlapping(string[] pointMaps)
    {
        var board = new int[1000][];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new int[1000];
        }

        // Populate lines across the array one by one
        foreach (var pointMap in pointMaps)
        {
            var pointMapSplit = pointMap.Split(" -> ");
            var point1 = pointMapSplit[0].Split(',').Select(int.Parse).ToArray();
            var point2 = pointMapSplit[1].Split(',').Select(int.Parse).ToArray();
            var (x1, y1, x2, y2) = (point1[0], point1[1], point2[0], point2[1]);

            // only operate on horizontal or vertical lines and increment value when adding a line
            if (x1 == x2)
            {
                var lowerBound = Math.Min(y1, y2);
                var upperBound = Math.Max(y1, y2) + 1;

                for (int i = lowerBound; i < upperBound; i++)
                {
                    board[x1][i]++;
                }
            }

            if (y1 == y2)
            {
                var lowerBound = Math.Min(x1, x2);
                var upperBound = Math.Max(x1, x2) + 1;
                var valuesToChange = board[lowerBound..upperBound];
                foreach (var value in valuesToChange)
                {
                    value[y1]++;
                }
            }
        }

        return board.SelectMany(x => x).Count(x => x >= 2);
    }

    public static int ProcessInputFindOverlappingWithDiagonal(string[] pointMaps)
    {
        var board = new int[1000][];
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new int[1000];
        }

        // Populate lines across the array one by one
        foreach (var pointMap in pointMaps)
        {
            var pointMapSplit = pointMap.Split(" -> ");
            var point1 = pointMapSplit[0].Split(',').Select(int.Parse).ToArray();
            var point2 = pointMapSplit[1].Split(',').Select(int.Parse).ToArray();
            var (x1, y1, x2, y2) = (point1[0], point1[1], point2[0], point2[1]);

            // O on horizontal or vertical lines and increment value when adding a line
            if (x1 == x2)
            {
                var lowerBound = Math.Min(y1, y2);
                var upperBound = Math.Max(y1, y2) + 1;

                for (int i = lowerBound; i < upperBound; i++)
                {
                    board[x1][i]++;
                }
            }
            else if (y1 == y2)
            {
                var lowerBound = Math.Min(x1, x2);
                var upperBound = Math.Max(x1, x2) + 1;
                var valuesToChange = board[lowerBound..upperBound];
                foreach (var value in valuesToChange)
                {
                    value[y1]++;
                }
            }
            // If the line is a diagonal, add that line
            else
            {
                var rangeX = Enumerable.Range(Math.Min(x1, x2), Math.Max(x1, x2) + 1 - Math.Min(x1, x2));
                var rangeY = Enumerable.Range(Math.Min(y1, y2), Math.Max(y1, y2) + 1 - Math.Min(y1, y2));
                if (x1 > x2)
                {
                    rangeX = rangeX.Reverse();
                }
                if (y1 > y2)
                {
                    rangeY = rangeY.Reverse();
                }
                var coords = Enumerable.Zip(rangeX, rangeY);
                foreach(var (x, y) in coords)
                {
                    board[x][y]++;
                }
            }

        }

        return board.SelectMany(x => x).Count(x => x >= 2);
    }
}

