using System.Collections.Generic;
using System.Linq;
using AdventOfCode1.Solutions;
using Xunit;

namespace Tests
{
    public class Day7Tests
    {
        private const string InputString = "16,1,2,0,4,2,7,1,2,14";
        private readonly IEnumerable<int> _puzzleInput;
        private readonly Day7 _day7 = new Day7();

        public Day7Tests()
        {
            _puzzleInput = Day7.ParseInput(InputString);
        }

        [Fact]
        public void GetMedian()
        {
            Assert.Equal(2, Day7.GetMedian(_puzzleInput.ToList()));
        }


        //[Fact]
        //public void GetMean()
        //{
        //    Assert.Equal(5, Day7.GetMean(_puzzleInput.ToList()));
        //}


        [Fact]
        public void GetFuelConsumption1()
        {
            Assert.Equal(37, Day7.GetFuelConsumption1(_puzzleInput.ToList()));
        }

        //[Fact]
        //public void GetFuelConsumption2()
        //{
        //    Assert.Equal(168, Day7.GetFuelConsumption2(_puzzleInput.ToList()));
        //}

        [Fact]
        public void GetSingleCrabConsumption()
        {
            Assert.Equal(66, Day7.GetSingleCrabConsumption(16, 5));
            Assert.Equal(10, Day7.GetSingleCrabConsumption(1, 5));
            Assert.Equal(3, Day7.GetSingleCrabConsumption(7, 5));
        }
    }
}
