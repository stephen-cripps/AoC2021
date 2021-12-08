using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode1.Extensions;
using AdventOfCode1.Solutions;
using Xunit;

namespace Tests
{
    public class Day4Tests
    {
        private readonly Day4 _day4;
        private readonly List<int> _numbers = new(){ 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };

        private readonly string _boardInput = @"
22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

        private readonly int[][,] _boards; 

        public Day4Tests()
        {
            _day4 = new Day4();
            
            _boards = _day4.ParseInput(_boardInput);
        }

        [Fact]
        public void GetWinnerTest()
        {
            var (number ,board,index ) = _day4.GetWinningBoard(_numbers, _boards);

            var sum = board.Cast<int>().Where(cell => cell > -1).Sum();

            Assert.Equal(188, sum);
            Assert.Equal(4512, number * sum);
        }

        [Fact]
        public void Solution2Test()
        {
            var (number, board) = _day4.GetLosingBoard(_numbers, _boards);

            var sum = board.Cast<int>().Where(cell => cell > -1).Sum();

            Assert.Equal(148, sum);
            Assert.Equal(13, number);
            Assert.Equal(1924, number * sum);
        }
    }
}
