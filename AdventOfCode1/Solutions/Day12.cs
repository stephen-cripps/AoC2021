namespace AdventOfCode1.Solutions
{
    public class Day12
    {
        private IEnumerable<string[]> _puzzleInput;

        public Day12()
        {
            _puzzleInput = ParseInput(File.ReadAllText("./Puzzle Inputs/Day12.txt"));
        }


        public int Solution1() => GetPathCount(_puzzleInput);
        public int Solution2() => GetPathCount(_puzzleInput,true);

        public static IEnumerable<string[]> ParseInput(string input) => input
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Split("-", StringSplitOptions.RemoveEmptyEntries));

        public static int GetPathCount(IEnumerable<string[]> input, bool v2 = false)
        {
            var connections = GetConnections(input);
            var paths = new List<List<string>> { new() { "start" } };

            while (true)
            {
                var unfinishedPaths = paths.Where(p => p.Last() != "end")
                    .ToList();

                if (!unfinishedPaths.Any())
                    return paths.Count;

                var newPaths = paths.Where(p => p.Last() == "end")
                    .ToList();

                foreach (var path in unfinishedPaths)
                {
                    var nextSteps = v2 ? GetNextStepsV2(connections, path) : GetNextSteps(connections, path);

                    newPaths.AddRange(nextSteps
                        .Select(step => path.Append(step).ToList()));
                }

                paths = newPaths;
            }
        }

        public static Dictionary<string, List<string>> GetConnections(IEnumerable<string[]> input)
        {
            var connections = new Dictionary<string, List<string>>();

            foreach (var line in input)
            {
                if (connections.ContainsKey(line[0]) && !connections[line[0]].Contains(line[1]))
                    connections[line[0]].Add(line[1]);
                else
                    connections[line[0]] = new List<string>() { line[1] };

                if (connections.ContainsKey(line[1]) && !connections[line[1]].Contains(line[0]))
                    connections[line[1]].Add(line[0]);
                else
                    connections[line[1]] = new List<string>() { line[0] };

            }
            return connections;
        }

        public static IEnumerable<string> GetNextSteps(Dictionary<string, List<string>> connections,
            List<string> currentPath)
        {
            var visitedSmallCaves = currentPath.Where(c => c.ToLower() == c);
            var currentCave = currentPath.Last();

            return connections[currentCave].Where(c => !visitedSmallCaves.Contains(c));
        }

        public static IEnumerable<string> GetNextStepsV2(Dictionary<string, List<string>> connections,
            List<string> currentPath)
        {
            var visitedSmallCaves = currentPath.Where(c => c.ToLower() == c)
                .ToList();

            var hasDoubleSteppedSmall = visitedSmallCaves.ToHashSet().Count() != visitedSmallCaves.Count();
            var currentCave = currentPath.Last();

            return hasDoubleSteppedSmall ? connections[currentCave].Where(c => !visitedSmallCaves.Contains(c))
                    : connections[currentCave].Where(c => c != "start");
        }
    }
}