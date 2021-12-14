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

    public int Solution1() => GetCommonalityDiff(_polymer, _insertions, 10);
    public int Solution2() => 0;

    public static int GetCommonalityDiff(string polymer, Dictionary<string, string> insertions, int n)
    {
        var result = ApplyNInsertions(polymer, insertions, n);

        var groupedResult = result.GroupBy(i => i)
            .OrderByDescending(grp => grp.Count());

        return groupedResult.First().Count() - groupedResult.Last().Count();
    }

    public static string ApplyNInsertions(string polymer, Dictionary<string, string> insertions, int n)
    {
        var result = new string(polymer);

        for (var i = 0; i < n; i++)
            result = ApplyInsertionStep(result, insertions);

        return result;
    }

    public static string ApplyInsertionStep(string polymer, Dictionary<string, string> insertions)
    {
        var result = "";

        for (var i = 0; i < polymer.Length - 1; i++)
        {
            result += polymer[i];

            if (insertions.TryGetValue("" + polymer[i] + polymer[i + 1], out var insertion))
                result += insertion;
        }

        result += polymer.Last();

        return result;
    }

}
