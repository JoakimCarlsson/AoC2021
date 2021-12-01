namespace AoC2021.Days;

public static class Day1
{
    public static void Day1Solve()
    {
        var input = File.ReadAllLines("day1.txt");
        var inputParsed = new long[input.Length];
        for (var i = 0; i < input.Length; i++)
            inputParsed[i] = long.Parse(input[i]);

        long part1Prev = 0;
        long part2Prev = 0;
        long part1Counter = 0;
        long part2Counter = 0;

        for (var i = 0; i < input.Length; i++)
        {
            if (i != 0)
            {
                var p1Next = inputParsed[i];
                if (p1Next > part1Prev)
                    part1Counter++;
                part1Prev = p1Next;

                if (i >= inputParsed.Length - 2) continue;
                var p2Next = inputParsed[i] + inputParsed[i + 1] + inputParsed[i + 2];
                if (p2Next > part2Prev)
                    part2Counter++;
                part2Prev = p2Next;
            }
            else
            {
                part1Prev = inputParsed[i];
                part2Prev = inputParsed[i] + inputParsed[i + 1] + inputParsed[i + 2];
            }
        }
        Console.WriteLine($"Part 1: {part1Counter}");
        Console.WriteLine($"Part 2: {part2Counter}");
    }
}