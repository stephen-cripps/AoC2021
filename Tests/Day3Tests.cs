using System.Collections.Generic;
using AdventOfCode1.Solutions;
using Xunit;

namespace Tests
{
    public class Day3Tests
    {
        private readonly Day3 _day3;

        private IEnumerable<string> _input = new List<string>()
        {
            "00100", "11110", "10110", "10111", "10101", "01111",
            "00111", "11100", "10000", "11001", "00010", "01010"
        };

        public Day3Tests()
        {
            _day3 = new Day3(); 
        }

        [Fact]
        public void OxygenTest()
        {
           var result = _day3.GetOxygenValue(_input);

           Assert.Equal(23, result);
        }

        [Fact]
        public void Co2Test()
        {
            var result = _day3.GetCo2Value(_input);

            Assert.Equal(10, result);
        }
    }
}