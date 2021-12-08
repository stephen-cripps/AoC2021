namespace AdventOfCode1.Solutions
{
    public class Day5
    {
        private readonly IEnumerable<int[]> _parsedInput;

        public Day5()
        {
            _parsedInput = ParseInput(File.ReadAllText("./Puzzle Inputs/Day5.txt"));
        }

        public static IEnumerable<int[]> ParseInput(string input) =>
            input.Replace(" -> ", ",")
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(value => Convert.ToInt32(value))
                    .ToArray());

        public int Solution1()
        {//6687
            var pipes = GetPerpendicularPipes(_parsedInput);

            return CountOverlaps(pipes);
        }

        public int Solution2() => CountOverlaps(_parsedInput);

        public int CountOverlaps(IEnumerable<int[]> input)
        {
            var pipes = input.Select(i=> GetFullPipeCoords(new []{i[0], i[1]}, new [] {i[2], i[3]})).ToList();
            var pipeCoordinates = pipes.SelectMany(p => p.Select(c => string.Join(",", c)));

            var pipeCount = new Dictionary<string, int>();

            foreach (var pipe in pipeCoordinates)
            {
                if (pipeCount.ContainsKey(pipe))
                    pipeCount[pipe]++;
                else
                    pipeCount[pipe] = 1;
            }

            return pipeCount.Count(p => p.Value > 1);
        }

        public IEnumerable<int[]> GetPerpendicularPipes(IEnumerable<int[]> input) => input.Where(i => i[0] == i[2] || i[1] == i[3]);

        private IEnumerable<int[]> GetFullPipeCoords(int[] start, int[] end)
        {
            var fullPipe = new List<int[]>();

            var xIsAscending = start[0] < end[0];
            var xIsDescending = start[0] > end[0];
            var x = start[0];

            var yIsAscending = start[1] < end[1];
            var yIsDescending = start[1] > end[1];
            var y = start[1];

            while(!(x == end[0] && y == end [1]))
            {
                fullPipe.Add(new[] { x, y});

                if (xIsAscending)
                    x++;
                else if (xIsDescending)
                    x--;

                if (yIsAscending)
                    y++;
                else if (yIsDescending)
                    y--;
            }

            fullPipe.Add(new[] { x, y });

            return fullPipe;
        }
    }
}
