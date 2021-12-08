namespace AdventOfCode1.Solutions
{
    public class Day2
    {
        private readonly IEnumerable<KeyValuePair<string, int>> _puzzleInput;

        public Day2()
        {
            var inputString = File.ReadAllText("./Puzzle Inputs/Day2.txt");
            _puzzleInput = inputString.Split("\r\n")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(i => i.Split(' '))
                .Select(i => new KeyValuePair<string,int>(i[0], Convert.ToInt32(i[1])));
        }

        public int Solution1()
        {
            //ans 1654760
            var horizontalPosition = _puzzleInput
                .Where(i => i.Key == "forward")
                .Select(i => i.Value)
                .Sum();

            var verticalPosition = _puzzleInput
                .Where(i => i.Key != "forward")
                .Select(i => i.Key == "down" ? i.Value : -i.Value)
                .Sum();

            return horizontalPosition * verticalPosition;
        }

        public int Solution2()
        {
            //1956047400
            var aim = 0;
            var x = 0;
            var y = 0;

            foreach (var (key, value) in _puzzleInput)
            {
                switch (key)
                {
                    case "forward":
                        x += value;
                        y += aim * value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    case "down":
                        aim += value;
                        break;
                }
            }

            return x * y;
        }
    }
}
