using System.Collections.Generic;
using System.Linq;
using AdventOfCode1.Solutions;
using Xunit;

namespace Tests
{
    public class Day5Tests
    {
        private readonly Day5 _day5;
        private readonly IEnumerable<int[]> _parsedInput;

        public const string input = @"
0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

        public Day5Tests()
        {
            _day5 = new Day5();
            _parsedInput = Day5.ParseInput(input);
        }

        [Fact]
        public void GetSol1OverlapsTest()
        {
            var pipes = _day5.GetPerpendicularPipes(_parsedInput);

            Assert.Equal(6, pipes.Count());
            
            var overlaps = _day5.CountOverlaps(pipes);

            Assert.Equal(5, overlaps);
        }

        [Fact]
        public void GetSol2OverlapsTest()
        {
            var overlaps = _day5.CountOverlaps(_parsedInput);

            Assert.Equal(12, overlaps);
        }
    }
}
