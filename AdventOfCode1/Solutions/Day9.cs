using AdventOfCode1.Extensions;
using System.Linq;

namespace AdventOfCode1.Solutions
{
    public class Day9
    {
        private readonly int[,] _parsedInput;

        public Day9()
        {
            _parsedInput = ParseInput(File.ReadAllText("./Puzzle Inputs/Day9.txt"));
        }

        public int Solution1() => GetRiskLevelSum(_parsedInput);
        public long Solution2() => Get3BasinsProduct(_parsedInput);

        public static int[,] ParseInput(string inputString) =>
            inputString
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToArray()
                    .Select(c => (int)char.GetNumericValue(c)))
                .ToMultiArray();

        public static int GetRiskLevelSum(int[,] input)
        {
            var width = input.GetLength(1);
            var height = input.GetLength(0);

            var riskLevel = 0;

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (IsLowPoint(input, width, height, i, j)) riskLevel += input[j, i] + 1;
                }
            }

            return riskLevel;
        }

        public static int Get3BasinsProduct(int[,] input)
        {
            var width = input.GetLength(1);
            var height = input.GetLength(0);

            var basinSizes = new List<int>();

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (IsLowPoint(input, width, height, i, j))
                        basinSizes.Add(GetBasinSize(input, width, height, i, j));
                }
            }

            basinSizes.Sort();
            basinSizes.Reverse();

            return basinSizes[0] * basinSizes[1] * basinSizes[2];
        }

        public static bool IsLowPoint(int[,] input, int inputWidth, int inputHeight, int x, int y)
        {
            var adjacents = new List<int>();

            if (x > 0)
                adjacents.Add(input[y, x - 1]);
            if (x < inputWidth - 1)
                adjacents.Add(input[y, x + 1]);
            if (y > 0)
                adjacents.Add(input[y - 1, x]);
            if (y < inputHeight - 1)
                adjacents.Add(input[y + 1, x]);

            return adjacents.Min() > input[y, x];
        }

        public static int GetBasinSize(int[,] input, int inputWidth, int inputHeight, int x, int y)
        {
            var basinPoints = new List<int[]> { new[] { y,x } };
            var i = 0;

            while (i < basinPoints.Count())
            {
                var newAdjPoints =
                    GetAdjacentBasinPoints(input, inputWidth, inputHeight, basinPoints[i][1], basinPoints[i][0])
                        .Where(p => !basinPoints.Any(bp => bp.SequenceEqual(p)));

                basinPoints.AddRange(newAdjPoints);

                i++;
            }

            return basinPoints.Count();
        }

        public static List<int[]> GetAdjacentBasinPoints(int[,] input, int inputWidth, int inputHeight, int x, int y)
        {
            var adjacents = new List<int[]>();

            if (x > 0 && input[y, x - 1] != 9)
                adjacents.Add(new[] {y,x-1});
            if (x < inputWidth - 1 && input[y, x + 1] != 9)
                adjacents.Add(new[]{y,x+1});
            if (y > 0 && input[y - 1, x] != 9)
                adjacents.Add(new[]{y-1,x});
            if (y < inputHeight - 1 && input[y + 1, x] != 9)
                adjacents.Add(new[]{y+1,x});

            return adjacents;
        }
    }
}