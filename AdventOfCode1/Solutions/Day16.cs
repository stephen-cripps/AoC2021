using AdventOfCode1.Extensions;

namespace AdventOfCode1.Solutions;

public class Day16
{
    public List<int> Versions = new List<int>();

    public Day16()
    {
    }

    public int Solution1()
    {
        ParsePacket(GetBinary(File.ReadAllText("./Puzzle Inputs/Day16.txt")));
        return Versions.Sum();
    }

    public long Solution2() => ParsePacket(GetBinary(File.ReadAllText("./Puzzle Inputs/Day16.txt"))).value;

    public static string GetBinary(string input) =>
        input.Select(item => Convert.ToInt32(item.ToString(), 16))
            .Select(number => Convert.ToString(number, 2).PadLeft(4, '0'))
            .Aggregate("", (current, binary) => current + binary);

    public (long value, int length) ParsePacket(string input)
    {
        RecordVersion(input);

        var literal = input.Substring(3, 3) == "100";

        return literal ? ParseLiteral(input) : ParseOperator(input);
    }

    public (long value, int length) ParseOperator(string input) => input[6] == '0' ? ParseOperatorMode1(input) : ParseOperatorMode2(input);

    public (long value, int length) ParseOperatorMode1(string input)
    {
        var packetsLength = Convert.ToInt32(input.Substring(7, 15), 2);

        var remainingSubpackets = input[22..];

        var processedLength = 0;

        var values = new List<long>();

        while (processedLength < packetsLength)
        {
            var (value, length) = ParsePacket(remainingSubpackets);
            values.Add(value);

            processedLength += length;
            remainingSubpackets = remainingSubpackets[length..];
        }

        return (ProcessOperatorValues(input, values), packetsLength + 22);
    }

    public (long value, int length) ParseOperatorMode2(string input)
    {
        var numPackets = Convert.ToInt32(input.Substring(7, 11), 2);

        var remainingSubpackets = input[18..];

        var processedLength = 0;

        var values = new List<long>();

        for (var i = 0; i < numPackets; i++)
        {
            var (value, length) = ParsePacket(remainingSubpackets);

            values.Add(value);
            processedLength += length;
            remainingSubpackets = remainingSubpackets[length..];
        }

        return (ProcessOperatorValues(input, values), processedLength + 18);
    }

    public long ProcessOperatorValues(string input, List<long> values)
    {
        switch (Convert.ToInt32(input.Substring(3, 3), 2))
        {
            case 0:
                return values.Sum();
            case 1:
                long prod = 1;
                values.ForEach(x => prod *= x);
                return prod;
            case 2:
                return values.Min();
            case 3:
                return values.Max();
            case 4:
                throw new ArgumentException("Input is a literal");
            case 5:
                return values[0] > values[1] ? 1 : 0;
            case 6:
                return values[0] < values[1] ? 1 : 0;
            case 7:
                return values[0] == values[1] ? 1 : 0;
            default:
                throw new ArgumentException("Input has invalid ID");
        }
    }

    public (long value, int length) ParseLiteral(string input)
    {
        var headerless = input[6..];
        var output = "";
        var i = 0;

        while (true)
        {
            var currentGroup = headerless.Substring(i * 5, 5);

            output += currentGroup[1..];

            i++;

            if (currentGroup[0] == '0')
                return (Convert.ToInt64(output, 2), 6 + i * 5);
        }
    }

    private void RecordVersion(string input) => Versions.Add(Convert.ToInt32(input[..3], 2));

}
