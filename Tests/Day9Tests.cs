using System.Collections.Generic;
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
            Assert.True(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 1, 0));
            Assert.True(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 9, 0));
            Assert.True(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 2, 2));
            Assert.True(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 6, 4));

            Assert.False(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 4, 3));
            Assert.False(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 0, 0));
            Assert.False(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 9, 2));
            Assert.False(Day9.IsLowPoint(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 6, 3));
        }

        [Fact]
        public void GetRiskLevelSum()
        {
            Assert.Equal(15, Day9.GetRiskLevelSum(_puzzleInput));
        }

        [Fact]
        public void GetAdjacentBasinPoints()
        {
            var ans = new List<int[]>() { new[]{0,0} };
            Assert.Equal(ans, Day9.GetAdjacentBasinPoints(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 1, 0));

            ans = new List<int[]>() { new[]{2,2}, new[]{2,4}, new[]{1,3}, new[]{3,3} };
            Assert.Equal(ans, Day9.GetAdjacentBasinPoints(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 3, 2));
        }

        [Fact]
        public void GetBasinSize()
        {
            Assert.Equal(3, Day9.GetBasinSize(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 1, 0));
            Assert.Equal(9, Day9.GetBasinSize(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 9, 0));
            Assert.Equal(14, Day9.GetBasinSize(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 2, 2));
            Assert.Equal(9, Day9.GetBasinSize(_puzzleInput, _puzzleInput.GetLength(1), _puzzleInput.GetLength(0), 6, 4));
        }   
        
        [Fact]
        public void Get3BasinsProduct()
        {
            Assert.Equal(1134, Day9.Get3BasinsProduct(_puzzleInput));
        }
    }
}