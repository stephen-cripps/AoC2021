using AdventOfCode1.Extensions;

namespace AdventOfCode1.Solutions
{
    public class Day11
    {
        public int[,] Input;
        public int Flashes;
        private readonly List<int[]> _alreadyFlashed = new ();

        public Day11(string input)
        {
            Input = input.ToMultiIntArray();
        }

        public int Solution1() => FlashesAfterNSteps(100);
        public int Solution2() => GetFirstSimultaneous();

        public int FlashesAfterNSteps(int steps)
        {
            for (var i = 0; i < steps; i++)
                Step();

            return Flashes;
        }

        public int GetFirstSimultaneous()
        {
            var i = 1;
            while (true)
            {
                if (Step())
                    return i;

                i++;
            }
        }

        //Returns true if simul
        public bool Step()
        {
            var width = Input.GetLength(0);
            var height = Input.GetLength(1);

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (_alreadyFlashed.Count == Input.Length)
                    {
                        _alreadyFlashed.Clear();
                        return true;
                    }
                    IncreaseEnergyLevel(i, j);
                }
            }

            _alreadyFlashed.Clear();
            return false;
        }

        public void IncreaseEnergyLevel(int i, int j)
        {
            var ijArray = new[] { i, j };
            if (_alreadyFlashed.Any(flash => flash.SequenceEqual(ijArray)))
                return;

            Input[i, j]++;
            if (Input[i, j] != 10) return;

            Flashes++;
            Input[i, j] = 0;
            _alreadyFlashed.Add(ijArray);

            IncreaseAdjacent(i, j);
        }

        public void IncreaseAdjacent(int i, int j)
        {
            int GetMin(int x) => x == 0 ? 0 : x - 1;
            int GetMax(int x, int size) => x == size - 1 ? x : x + 1;

            for (var k = GetMin(i); k <= GetMax(i, Input.GetLength(0)); k++)
            {
                for (var l = GetMin(j); l <= GetMax(j, Input.GetLength(1)); l++)
                {
                    if (k == i && l == j) continue;
                    IncreaseEnergyLevel(k, l);
                }
            }
        }
    }
}