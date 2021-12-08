namespace AdventOfCode1.Solutions
{
    public class Day6
    {
        private readonly IEnumerable<int> _parsedInput;
        private readonly Dictionary<string, long> _lookup = new();

        public Day6()
        {
            _parsedInput = ParseInput(File.ReadAllText("./Puzzle Inputs/Day6.txt"));
        }

        public long Solution1() => CountFish(_parsedInput, 80);
        public long Solution2() => CountFish(_parsedInput, 256);

        public static IEnumerable<int> ParseInput(string inputString) => inputString.Split(",").Select(int.Parse);

        public long CountFish(IEnumerable<int> input, int numDays) => input.Sum(fish => CountAllDescendents(fish, numDays) + 1);

        public long CountAllDescendents(int initialNumber, int days)
        {
            var lookupKey = ($"{initialNumber},{days}");
            if(_lookup.ContainsKey(lookupKey))
               return _lookup[lookupKey];

            var numChildren = GetNumChildren(initialNumber, days);

            var numDescendents = numChildren;

            for (var i = days - initialNumber -1; i > 0; i -= 7)
            {
                numDescendents += CountAllDescendents(8, i);
            }

            _lookup[lookupKey] = numDescendents;

            return numDescendents;
        }

        public static long GetNumChildren(int initialNumber, int days)
        {
            if (days < initialNumber)
                return 0;

            return (int)Math.Ceiling((double)(days - initialNumber) / 7);
        }
    }
}
