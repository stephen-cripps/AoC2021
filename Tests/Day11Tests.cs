using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode1.Extensions;
using AdventOfCode1.Solutions;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class Day11Tests
    {
        private const string InputString = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

        private Day11 _day11;
        private readonly ITestOutputHelper _testOutputHelper;

        public Day11Tests(ITestOutputHelper testOutputHelper)
        {
            _day11 = new Day11(InputString);
        }

        [Fact]
        public void Step()
        {
            _day11.Step();

            Assert.Equal(0, _day11.Flashes);    
            Assert.Equal(_afterStep1, _day11.Input);    
            
            _day11.Step();
            Assert.Equal(35, _day11.Flashes);
            Assert.Equal(_afterStep2, _day11.Input);

            _day11.Step();
            Assert.Equal(_afterStep3, _day11.Input);

            _day11.Step();
            _day11.Step();
            Assert.Equal(_afterStep5, _day11.Input);

            _day11.Step();
            _day11.Step();
            _day11.Step();
            _day11.Step();
            _day11.Step();
            Assert.Equal(_afterStep10, _day11.Input);
        }

        public void WriteInput()
        {
            var input = _day11.Input;
            var width = input.GetLength(0);
            var height = input.GetLength(1);

            for (var i = 0; i < width; i++)
            {
                var line = "";
                for (var j = 0; j < height; j++)
                {
                    line+=input[i, j];
                }
                _testOutputHelper.WriteLine(line);
            }
            _testOutputHelper.WriteLine("");
        }


        [Fact]
        public void FlashesAfterNSteps()
        {
            Assert.Equal(204, _day11.FlashesAfterNSteps(10));

            _day11= new Day11(InputString);
            var result = _day11.FlashesAfterNSteps(100);
            Assert.Equal(1656, result);

            _day11 = new Day11(InputString);
            _day11.FlashesAfterNSteps(193);
            WriteInput();
            _day11.Step();
            WriteInput();
            _day11.Step();
            WriteInput();
        }

        [Fact]
        public void GetFirstSimultaneous()
        {
            Assert.Equal(195, _day11.GetFirstSimultaneous());
        }

        private readonly int[,] _afterStep1 = @"
6594254334
3856965822
6375667284
7252447257
7468496589
5278635756
3287952832
7993992245
5957959665
6394862637".ToMultiIntArray();

        private readonly int[,] _afterStep2 = @"
8807476555
5089087054
8597889608
8485769600
8700908800
6600088989
6800005943
0000007456
9000000876
8700006848".ToMultiIntArray();

        private readonly int[,] _afterStep3 = @"
0050900866
8500800575
9900000039
9700000041
9935080063
7712300000
7911250009
2211130000
0421125000
0021119000".ToMultiIntArray();

        private readonly int[,] _afterStep5 = @"
4484144000
2044144000
2253333493
1152333274
1187303285
1164633233
1153472231
6643352233
2643358322
2243341322".ToMultiIntArray();

        private readonly int[,] _afterStep10 = @"
0481112976
0031112009
0041112504
0081111406
0099111306
0093511233
0442361130
5532252350
0532250600
0032240000".ToMultiIntArray();

        private readonly int[,] _afterStep100 = @"
0397666866
0749766918
0053976933
0004297822
0004229892
0053222877
0532222966
9322228966
7922286866
6789998766".ToMultiIntArray();
    }
}