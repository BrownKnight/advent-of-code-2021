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
            var grouped = numbers
                .Select(x => x & testNum)
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count());
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

    public static (int gamma, int epsilon) CalculateOxygenReadings(string[] data)
    {
        var numBits = data.First().Length;
        var numbers = data.Select(x => Convert.ToInt32(x, 2));

        IEnumerable<int> oxygenReadings = numbers;
        IEnumerable<int> co2Readings = numbers;

        for (var i = numBits - 1; i >= 0; i--)
        {
            var mask = ((int)Math.Pow(2, i));

            if (oxygenReadings.Count() > 1)
            {
                var mostCommonFirstBit =
                    oxygenReadings
                        .Select(x => x & mask)
                        .GroupBy(x => x)
                        .OrderByDescending(x => x.Count())
                        .ThenByDescending(x => x.Key)
                        .First().Key;

                oxygenReadings =
                    mostCommonFirstBit == 0
                        ? oxygenReadings.Where(x => (x & mask) == 0)
                        : oxygenReadings.Where(x => (x & mask) != 0);
            }

            if (co2Readings.Count() > 1)
            {
                var leastCommonFirstBit =
                    co2Readings
                        .Select(x => x & mask)
                        .GroupBy(x => x)
                        .OrderBy(x => x.Count())
                        .ThenBy(x => x.Key)
                        .First().Key;

                co2Readings =
                    leastCommonFirstBit == 0
                        ? co2Readings.Where(x => (x & mask) == 0)
                        : co2Readings.Where(x => (x & mask) != 0);
            }
        }

        return (oxygenReadings.First(), co2Readings.First());
    }
}
