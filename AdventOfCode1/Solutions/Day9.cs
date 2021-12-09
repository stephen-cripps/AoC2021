using AdventOfCode1.Extensions;

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
        //public long Solution2() => GetFuelConsumption2(_parsedInput.ToList());

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

            return adjacents.Min() > input[y,x];
        }
    }
}