using System.Collections;

namespace AdventOfCode1.Solutions;

public class Day13
{
    private IEnumerable<int[]> _dots;
    private IEnumerable<string[]> _folds;

    public Day13()
    {
        (_dots, _folds) = ParseInput(File.ReadAllText("./Puzzle Inputs/Day13.txt"));
    }


    public int Solution1() => ApplyFold(_dots.ToList(), _folds.ToArray()[0]).Count();
    public void Solution2()
    { 
 var solution = new List<int[]>(_dots);
        solution = _folds.Aggregate(solution, (current, fold) => ApplyFold(current, fold).ToList());

        var maxX = solution.ToList().Select(d => d[0]).Max();
        var maxY = solution.ToList().Select(d => d[1]).Max();
        var minX = solution.ToList().Select(d => d[0]).Min();
        var minY = solution.ToList().Select(d => d[1]).Min();

        Console.WriteLine(maxX + "," + maxY);
        Console.WriteLine(minX + "," + minY);

        for (var i = 0; i <= maxY; i++)
        {
            for (var j = 0; j <= maxX; j++)
            {
                Console.Write(solution.Any(s => s[0] == j && s[1] == i) ? "#" : ".");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static (IEnumerable<int[]> _dots, IEnumerable<string[]> _folds) ParseInput(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var dots = new List<int[]>();
        var folds = new List<string[]>();

        foreach (var line in lines)
        {
            if (line.Contains("fold along"))
            {
                var info = line.Split(' ').Last();
                folds.Add(info.Split("="));
            }
            else
            {
                dots.Add(line.Split(',')
                    .Select(l => Convert.ToInt32(l))
                    .ToArray());
            }
        }

        return (dots, folds);
    }

    public static IEnumerable<int[]> ApplyFold(List<int[]> dots, string[] fold)
    {
        IEnumerable<int[]> newDots;
        IEnumerable<int[]> staticDots;

        var foldInt = Convert.ToInt32(fold[1]);

        if (fold[0] == "x")
        {
            newDots = dots.Where(d => d[0] > foldInt)
                .Select(d => new[] { 2 * foldInt - d[0], d[1] });
            staticDots = dots.Where(d => d[0] < foldInt);
        }
        else
        {
            newDots = dots.Where(d => d[1] > foldInt)
                .Select(d => new[] { d[0], 2 * foldInt - d[1] });
            staticDots = dots.Where(d => d[1] < foldInt);
        }

        var fullDots = staticDots.ToList();

        newDots = newDots.Where(d => !fullDots.Any(fd => fd.SequenceEqual(d)));

        fullDots.AddRange(newDots);

        return fullDots;

    }
}
