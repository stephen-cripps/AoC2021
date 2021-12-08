namespace AdventOfCode1.Solutions
{
    public class Day1
    {
        private readonly int[] _puzzleInput;

        public Day1()
        {
            var inputString = File.ReadAllText("./Puzzle Inputs/Day1.txt");
            _puzzleInput = inputString.Split("\r\n")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(i => Convert.ToInt32(i))
                .ToArray();
        }
        public int Solution1()
        {
            //1215
            return GetAscendingCount(_puzzleInput);
        }

        public int Solution2()
        {
            //1150
            var adjustedArray = _puzzleInput
                    .SkipLast(2)
                    .Select((number, index) => number + _puzzleInput[index + 1] + _puzzleInput[index + 2])
                    .ToArray();

            return GetAscendingCount(adjustedArray);
        }

        private static int GetAscendingCount(IReadOnlyList<int> puzzleInput) => puzzleInput
            .Skip(1)
            .Where((number, index) => number > puzzleInput[index])
            .Count();
    }
}
