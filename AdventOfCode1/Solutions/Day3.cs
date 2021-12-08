using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1.Solutions
{
    public class Day3
    {
        private readonly IEnumerable<string> _puzzleInput;

        public Day3()
        {
            var inputString = File.ReadAllText("./Puzzle Inputs/Day3.txt");
            _puzzleInput = inputString.Split("\r\n")
                .Where(x => !string.IsNullOrWhiteSpace(x));
        }

        public int Solution1()
        {
            //3882564
            var gammaArray = GetGammaEnumerable(_puzzleInput);

            var gamma = EnumerableToInt(gammaArray);
            var epsilon = EnumerableToInt(GammaToEpsilon(gammaArray));

            return gamma * epsilon;
        }

        public int Solution2()
        {
            return GetOxygenValue(_puzzleInput) * GetCo2Value(_puzzleInput);
        }

        private static IEnumerable<char> GetGammaEnumerable(IEnumerable<string> input)
        {
            var totals = new int[input.First().Length];

            foreach (var s in input)
            {
                for (var i = 0; i < s.Length; i++)
                {
                    if (s[i] == '1')
                        totals[i]++;
                    else
                        totals[i]--;
                }
            }

            return totals.Select(t => (t >= 0 ? '1' : '0'));
        }

        private static IEnumerable<char> GammaToEpsilon(IEnumerable<char> gamma) => gamma.Select(i => i == '1' ? '0' : '1');

        private static int EnumerableToInt(IEnumerable<char> arr) => Convert.ToInt32(string.Join("", arr), 2);

        public int GetOxygenValue(IEnumerable<string> input)
        {
            var index = 0;

            var currentList = input.ToList();
            while (currentList.Count > 1)
            {
                var gamma = GetGammaEnumerable(currentList);
                currentList = new List<string>(currentList.Where(s => s[index] == gamma.ToArray()[index]));
                index++;
            }

            return EnumerableToInt(currentList.First());
        }

        public int GetCo2Value(IEnumerable<string> input)
        {
            var index = 0;

            var currentList = input.ToList();
            while (currentList.Count > 1)
            {
                var epsilon = GammaToEpsilon(GetGammaEnumerable(currentList));
                currentList = new List<string>(currentList.Where(s => s[index] == epsilon.ToArray()[index]));
                index++;
            }

            return EnumerableToInt(currentList.First());
        }
    }
}
