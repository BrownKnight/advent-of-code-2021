namespace AdventOfCode;

public class Day3
{
    public static (int gamma, int epsilon) ProcessReadings(string[] data)
    {
        var numBits = data.First().Length;
        var numbers = data.Select(x => Convert.ToInt32(x, 2));

        var gamma = 0;
        var epsilon = 0;

        for (var i = 0; i < numBits; i++)
        {
            var testNum = ((int)Math.Pow(2, i));
            var grouped = numbers.Select(x => x & testNum).GroupBy(x => x).OrderByDescending(x => x.Count());
            var mostCommon = grouped.First().Key;
            if (mostCommon > 0)
            {
                gamma += testNum;
            }
            else
            {
                epsilon += testNum;
            }
        }

        return (gamma, epsilon);
    }
}
