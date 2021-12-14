namespace AdventOfCode1.Solutions;

public class Day14
{
    private string _polymer;
    private Dictionary<string, string> _insertions;

    public Day14()
    {
        (_polymer, _insertions) = ParseInput(File.ReadAllText("./Puzzle Inputs/Day14.txt"));
    }

    public static (string polymer, Dictionary<string, string> insertions) ParseInput(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var polymer = lines[0];

        var insertions = lines
            .Skip(1)
            .Select(l => l.Split(" -> "))
            .ToDictionary(l => l[0], l => l[1]);

        return (polymer, insertions);
    }

    public long Solution1() => GetCommonalityDiff(_polymer, _insertions, 10);
    public long Solution2() => GetCommonalityDiff(_polymer, _insertions, 40);

    public static long GetCommonalityDiff(string polymer, Dictionary<string, string> insertions, int n)
    {
        var elements = new Dictionary<string, long>();
        var pairs = new Dictionary<string, long>();
        var i = 0;

        foreach (var element in polymer)
        {
            elements.TryAdd(element.ToString(), 0);
            elements[element.ToString()]++;

            if (i >= polymer.Length - 1) continue;

            var pair = "" + polymer[i] + polymer[i + 1];
            pairs.TryAdd(pair,0);
            pairs[pair]++;

            i++;
        }

        for (var j = 0; j < n; j++)
        {
            var newPairs = new Dictionary<string, long>();
            foreach (var (pair, count) in pairs)
            {
                var insert = insertions[pair];
                elements.TryAdd(insert, 0);
                elements[insert] += count;

                var new1 = pair[0] + insert;
                var new2 = insert + pair[1];

                newPairs.TryAdd(new1, 0);
                newPairs[new1] += count;

                newPairs.TryAdd(new2, 0);
                newPairs[new2] += count;
            }

            pairs=newPairs;
        }

        var largest = elements.OrderBy(e => e.Value).Last().Value;
        var smallest = elements.OrderBy(e => e.Value).First().Value;

        return largest - smallest;
    }
}
