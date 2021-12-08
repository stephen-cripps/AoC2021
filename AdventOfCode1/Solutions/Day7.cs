using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1.Solutions
{
    public class Day7
    {
        private readonly IEnumerable<int> _parsedInput;

        public Day7()
        {
            _parsedInput = ParseInput(File.ReadAllText("./Puzzle Inputs/Day7.txt"));
        }

        public int Solution1() => GetFuelConsumption1(_parsedInput.ToList());
        public long Solution2() => GetFuelConsumption2(_parsedInput.ToList());

        public static IEnumerable<int> ParseInput(string inputString) => inputString.Split(",").Select(int.Parse);

        public static int GetFuelConsumption1(List<int> input)
        {
            var median = GetMedian(input);

            return input.Sum(i  => Math.Abs(i-median));    
        }

        public static long GetFuelConsumption2(List<int> input)
        {
            var mean = GetMean(input);

            return input.Sum(i => GetSingleCrabConsumption(i, mean));
        }

        public static long GetSingleCrabConsumption(int position, int target)
        {
            var distance = Math.Abs(position - target);

            var range = Enumerable.Range(1, distance);

            return range.Sum();
        }

        public static int GetMedian(List<int> input)
        {
            input.Sort();
            return input.Skip(input.Count() / 2)
                .First();
        }

        public static int GetMean(List<int> input) => (int)Math.Floor(input.Average());
        
    }
}
