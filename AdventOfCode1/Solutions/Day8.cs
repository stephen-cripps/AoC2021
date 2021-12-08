using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode1.Extensions;

namespace AdventOfCode1.Solutions
{
    public class Day8
    {

        private readonly string[][] _signalPatterns;
        private readonly string[][] _outputs;

        public Day8()
        {
            (_signalPatterns, _outputs) = Day8.ParseInput(File.ReadAllText("./Puzzle Inputs/Day8.txt"));
        }

        public static (string[][] signalPatterns, string[][] outputs) ParseInput(string inputString)
        {
            var entries = inputString.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var signalPatterns = entries.Select(i => i.Split("|", StringSplitOptions.RemoveEmptyEntries)[0])
                .Select(i => i.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                .ToArray();

            var outputs = entries.Select(i => i.Split("|", StringSplitOptions.RemoveEmptyEntries)[1])
                .Select(i => i.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                .ToArray();

            return (signalPatterns, outputs);
        }

        public int Solution1() => GetEasyDigitsInAllOutputs(_outputs);
        public int Solution2() => _outputs.Select((o,i) => GetOutputValue(o, _signalPatterns[i])).Sum();

        public static int GetEasyDigitsInAllOutputs(IEnumerable<string[]> outputStrings) => outputStrings
            .Select(GetEasyDigitsInOutput)
            .Sum();

        public static int GetEasyDigitsInOutput(IEnumerable<string> outputStrings) => outputStrings
            .Count(digit => digit.Length is 2 or 3 or 4 or 7);

        public static int GetOutputValue(IEnumerable<string> outputStrings, IEnumerable<string> signalPattern)
        {
            var one = signalPattern.Single(p => p.Length == 2);
            var four = signalPattern.Single(p => p.Length == 4);

            var result = "";

            foreach (var outputString in outputStrings)
            {
                switch (outputString.Length)
                {
                    case 2:
                        result += "1";
                        break;
                    case 3:
                        result += "7";
                        break;
                    case 4:
                        result += "4";
                        break;
                    case 5:
                        result += GetTwoThreeOrFive(outputString, one, four);
                        break;
                    case 6:
                        result += GetNineSixOrZero(outputString, one, four);
                        break;
                    case 7:
                        result += "8";
                        break;
                }
            }

            return int.Parse(result);
        }

        public static string GetNineSixOrZero(string value, string one, string four)
        {
            var chArr = value.ToCharArray();

            if (!chArr.ContainsAll(one.ToCharArray()))
                return "6";

            if (chArr.ContainsAll(four.ToCharArray()))
                return "9";

            return "0";
        }

        public static string GetTwoThreeOrFive(string value, string one, string four)
        {
            var chArr = value.ToCharArray();

            if (chArr.ContainsAll(one.ToCharArray()))
                return "3";

            if (chArr.Count(c => four.ToCharArray().Contains(c)) == 3)
                return "5";

            return "2";
        }
    }
}
