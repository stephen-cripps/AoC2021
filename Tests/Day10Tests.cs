using System.Collections.Generic;
using System.Linq;
using AdventOfCode1.Solutions;
using Xunit;

namespace Tests
{
    public class Day10Tests
    {
        private const string InputString = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]";

        private readonly List<string> _puzzleInput;

        public Day10Tests()
        {
            _puzzleInput = Day10.ParseInput(InputString).ToList();
        }

        [Fact]
        public void IsCorrectClosing()
        {
            Assert.True(Day10.IsCorrectClosingBracket('(', ')'));
            Assert.True(Day10.IsCorrectClosingBracket('{', '}'));
            Assert.True(Day10.IsCorrectClosingBracket('[', ']'));
            Assert.True(Day10.IsCorrectClosingBracket('<', '>'));
            Assert.False(Day10.IsCorrectClosingBracket('(', '>'));
            Assert.False(Day10.IsCorrectClosingBracket('{', ']'));
            Assert.False(Day10.IsCorrectClosingBracket('[', ')'));
            Assert.False(Day10.IsCorrectClosingBracket('<', ']'));
        }

        [Fact]
        public void GetFirstIllegal()
        {
            Assert.Equal('}', Day10.GetFirstIllegal(_puzzleInput[2]));
            Assert.Equal(')', Day10.GetFirstIllegal(_puzzleInput[4]));
            Assert.Equal(']', Day10.GetFirstIllegal(_puzzleInput[5]));
            Assert.Equal(')', Day10.GetFirstIllegal(_puzzleInput[7]));
            Assert.Equal('>', Day10.GetFirstIllegal(_puzzleInput[8]));
        }    
        
        [Fact]
        public void GetScore()
        {
            Assert.Equal(26397, Day10.GetSyntaxScore(_puzzleInput));
        }

        [Fact]
        public void DiscardInvalid()
        {
            var expected = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
(((({<>}<{<{<>}{[]{[]{}
{<[[]]>}<{[{[{[]{()[[[]
<{([{{}}[<[[[<>{}]]]>[]]";

            Assert.Equal(Day10.ParseInput(expected), Day10.DiscardInvalid(_puzzleInput));
        }

        [Fact]
        public void GetUnclosedParens()
        {
            var input = Day10.DiscardInvalid(_puzzleInput).ToList();
            Assert.Equal("[({([[{{", string.Join("", Day10.GetUnclosedParens(input[0])));
            Assert.Equal("({[<{(",string.Join("", Day10.GetUnclosedParens(input[1])));
            Assert.Equal("((((<{<{{", string.Join("", Day10.GetUnclosedParens(input[2])));
            Assert.Equal("<{[{[{{[[", string.Join("", Day10.GetUnclosedParens(input[3])));
            Assert.Equal("<{([", string.Join("", Day10.GetUnclosedParens(input[4])));
        }

        [Fact]
        public void GetCompletionChars()
        {
            var input = Day10.DiscardInvalid(_puzzleInput).ToList();
            Assert.Equal("}}]])})]", string.Join("", Day10.GetCompletionChars(Day10.GetUnclosedParens(input[0]))));
            Assert.Equal(")}>]})", string.Join("", Day10.GetCompletionChars(Day10.GetUnclosedParens(input[1]))));
            Assert.Equal("}}>}>))))", string.Join("", Day10.GetCompletionChars(Day10.GetUnclosedParens(input[2]))));
            Assert.Equal("]]}}]}]}>", string.Join("", Day10.GetCompletionChars(Day10.GetUnclosedParens(input[3]))));
            Assert.Equal("])}>", string.Join("", Day10.GetCompletionChars(Day10.GetUnclosedParens(input[4]))));
        }

        [Fact]
        public void GetCompletionScore()
        {
            Assert.Equal(288957, Day10.GetCompletionScore(_puzzleInput));   
        }

    }
}