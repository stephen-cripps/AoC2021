using System.Collections.Generic;
using System.Linq;
using AdventOfCode1.Solutions;
using Xunit;

namespace Tests
{
    public class Day9Tests
    {
        private const string InputString = @"2199943210
3987894921
9856789892
8767896789
9899965678";

        private readonly int[,] _puzzleInput;

        public Day9Tests()
        {
            _puzzleInput = Day9.ParseInput(InputString);
        }

        [Fact]
        public void IsLowPoint()
        {
            Assert.True(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 1,0));
            Assert.True(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 9,0));
            Assert.True(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 2,2));
            Assert.True(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 6,4));

            Assert.False(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 4,3));
            Assert.False(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 0,0));
            Assert.False(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 9,2));
            Assert.False(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 6,3));
        }    
        
        [Fact]
        public void GetRiskLevelSum()
        {
            Assert.Equal(15, Day9.GetRiskLevelSum(_puzzleInput));
        }
    }
}