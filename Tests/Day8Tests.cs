using AdventOfCode1.Solutions;
using Xunit;

namespace Tests
{
    public class Day8Tests
    {
        private const string InputString =
            @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb |fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec |fcgedb cgb dgebacf gc
fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef |cg cg fdcagb cbg
fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega |efabcd cedba gadfec cb
aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga |gecf egdcabf bgf bfgea
fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf |gebdcfa ecba ca fadegcb
dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf |cefg dcbef fcge gbcadfe
bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd |ed bcgafe cdgba cbgef
egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg |gbdfcae bgc cg cgb
gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc |fgae cfgab fg bagce";

        private readonly string[][] _signalPatterns;
        private readonly string[][] _outputs;
        private readonly Day8 _day8 = new Day8();

        public Day8Tests()
        {
            (_signalPatterns, _outputs) = Day8.ParseInput(InputString);
        }

        [Fact]
        public void GetEasyDigitsInOutput()
        {
            Assert.Equal(2, Day8.GetEasyDigitsInOutput(_outputs[0]));
            Assert.Equal(3, Day8.GetEasyDigitsInOutput(_outputs[1]));
            Assert.Equal(3, Day8.GetEasyDigitsInOutput(_outputs[2]));
            Assert.Equal(1, Day8.GetEasyDigitsInOutput(_outputs[3]));
        }   
        
        [Fact]
        public void GetEasyDigitsInAllOutputs()
        {
            Assert.Equal(26, Day8.GetEasyDigitsInAllOutputs(_outputs));
        }

        [Fact]
        public void GetNineSixOrZero()
        {
            Assert.Equal("9", Day8.GetNineSixOrZero("cefabd", "ab", "eafb"));
            Assert.Equal("6", Day8.GetNineSixOrZero("cdfgeb", "ab", "eafb"));
            Assert.Equal("0", Day8.GetNineSixOrZero("cagedb", "ab", "eafb"));
        }


        [Fact]
        public void GetTwoThreeOrFive()
        {
            Assert.Equal("2", Day8.GetTwoThreeOrFive("gcdfa", "ab", "eafb"));
            Assert.Equal("3", Day8.GetTwoThreeOrFive("fbcad", "ab", "eafb"));
            Assert.Equal("5", Day8.GetTwoThreeOrFive("cdfbe", "ab", "eafb"));
        }

        [Fact]
        public void GetOutputValue()
        {
            Assert.Equal(8394, Day8.GetOutputValue(_outputs[0], _signalPatterns[0]));
            Assert.Equal(9781, Day8.GetOutputValue(_outputs[1], _signalPatterns[1]));
            Assert.Equal(1197, Day8.GetOutputValue(_outputs[2], _signalPatterns[2]));
            Assert.Equal(9361, Day8.GetOutputValue(_outputs[3], _signalPatterns[3]));
        }
    }
}
