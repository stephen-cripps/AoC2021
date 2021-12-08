using System.Collections.Generic;
using AdventOfCode1.Solutions;
using Xunit;

namespace Tests
{
    public class Day6Tests
    {
        private const string InputString = "3,4,3,1,2";
        private readonly IEnumerable<int> _puzzleInput;
        private readonly Day6 _day6 = new Day6();


        public Day6Tests()
        {
            _puzzleInput = Day6.ParseInput(InputString);
        }

        [Fact]
        public void GetNumChildren()
        {
            Assert.Equal(0, Day6.GetNumChildren(3, 2));
            Assert.Equal(1, Day6.GetNumChildren(3, 5));
            Assert.Equal(2, Day6.GetNumChildren(3, 14));
        }

        [Fact]
        public void CountAllDescendents()
        {
            Assert.Equal(2, _day6.CountAllDescendents(6, 14));
            Assert.Equal(1, _day6.CountAllDescendents(0, 1));
            Assert.Equal(2, _day6.CountAllDescendents(0, 8));
            Assert.Equal(3, _day6.CountAllDescendents(0, 10));
            Assert.Equal(6, _day6.CountAllDescendents(0, 17));
        }

        [Fact]
        public void TestFishCount()
        {
            Assert.Equal(6, _day6.CountFish(_puzzleInput, 2));
            
            Assert.Equal(10, _day6.CountFish(_puzzleInput, 5));
            
            Assert.Equal(12, _day6.CountFish(_puzzleInput, 10));

            Assert.Equal(15, _day6.CountFish(_puzzleInput, 11));

            Assert.Equal(26, _day6.CountFish(_puzzleInput, 18));

            Assert.Equal(5934, _day6.CountFish(_puzzleInput, 80));

            Assert.Equal(26984457539, _day6.CountFish(_puzzleInput, 256));
        }
    }
}
