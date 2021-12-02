namespace AoC2021.Days;

public sealed record Instruction(string Direction, long Amount);

internal static class Day2
{
    internal static void Solve()
    {
        var input = File.ReadAllLines("day2.txt");
        var instructions = new List<Instruction>();

        foreach (var line in input)
        {
            var x = line.Split(' ');
            instructions.Add(new Instruction(x[0], Convert.ToInt64(x[1])));
        }

        PartOne(instructions);
        PartTwo(instructions);
    }

    private static void PartOne(List<Instruction> instructions)
    {
        long horizontal = 0;
        long depth = 0;

        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case {Direction: "forward"}:
                    horizontal += instruction.Amount;
                    break;

                case {Direction: "up"}:
                    depth -= instruction.Amount;
                    break;

                case {Direction: "down"}:
                    depth += instruction.Amount;
                    break;
            }
        }

        Console.WriteLine($"result: {horizontal*depth}");
    }

    private static void PartTwo(List<Instruction> instructions)
    {
        long horizontal = 0;
        long depth = 0;
        long aim = 0;

        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case {Direction: "forward"}:
                    horizontal += instruction.Amount;
                    depth += aim * instruction.Amount;
                    break;

                case {Direction: "up"}:
                    aim -= instruction.Amount;
                    break;

                case {Direction: "down"}:
                    aim += instruction.Amount;
                    break;
            }
        }
        Console.WriteLine($"result: {horizontal * depth}");
    }
}