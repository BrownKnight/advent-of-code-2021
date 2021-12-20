namespace AdventOfCode;

public class Day2
{
    public static (int horizontalPosition, int depth) ProcessMovements(string[] data)
    {
        var actions = data.Select(x => x.Split(' ', 2)).Select(x => (x[0], int.Parse(x[1])));

        var horizontalPosition = 0;
        var depth = 0;

        foreach (var (action, size) in actions)
        {
            switch (action)
            {
                case "forward":
                    horizontalPosition += size;
                    break;
                case "down":
                    depth += size;
                    break;
                case "up":
                    depth -= size;
                    break;
            }
        }

        return (horizontalPosition, depth);
    }

    public static (int horizontalPosition, int depth) ProcessMovementsWithAim(string[] data)
    {
        var actions = data.Select(x => x.Split(' ', 2)).Select(x => (x[0], int.Parse(x[1])));

        var horizontalPosition = 0;
        var depth = 0;
        var aim = 0;

        foreach (var (action, size) in actions)
        {
            switch (action)
            {
                case "forward":
                    horizontalPosition += size;
                    depth += aim * size;
                    break;
                case "down":
                    aim += size;
                    break;
                case "up":
                    aim -= size;
                    break;
            }
        }

        return (horizontalPosition, depth);
    }
}
