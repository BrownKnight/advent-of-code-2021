namespace AdventOfCode;

public class Day1
{
    public static (int numIncreased, int numDecreased) CountChanges(string[] data)
    {
        var numbers = data.Select(int.Parse);

        var previous = -1;
        var numIncreased = 0;
        var numDecreased = 0;
        foreach (var number in numbers)
        {
            if (previous == -1)
            {
                previous = number;
                continue;
            }

            if (number > previous)
            {
                numIncreased++;
            }
            else
            {
                numDecreased++;
            }

            previous = number;
        }

        return (numIncreased, numDecreased);
    }

    public static int CountChangesWithWindow(string[] data, int windowSize)
    {
        var numbers = data.Select(int.Parse).ToArray();

        var numIncreases = 0;

        var window1Start = 0;
        var window1End = windowSize;

        var window2Start = window1Start + 1;
        var window2End = window1End + 1;

        while (window2End <= numbers.Length)
        {
            var window1Sum = numbers[window1Start..window1End].Sum();
            var window2Sum = numbers[window2Start..window2End].Sum();
            if (window2Sum > window1Sum)
            {
                numIncreases++;
            }

            window1Start++;
            window1End++;
            window2Start++;
            window2End++;
        }

        return numIncreases;
    }
}
