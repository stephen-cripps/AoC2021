using System;
using System.Collections.Generic;
using AdventOfCode1.Solutions;
using Newtonsoft.Json;
using Xunit;

namespace Tests
{
    public class Day18Tests
    {


        [Fact]
        public void ExplodeNumber()
        {
            var target = JsonConvert.SerializeObject(Day18.StringToEntries("[[[[0,9],2],3],4]"));
            var actual = JsonConvert.SerializeObject(Day18.ExplodeNumber(Day18.StringToEntries("[[[[[9,8],1],2],3],4]")));
            Assert.Equal(target, actual);

            target = JsonConvert.SerializeObject(Day18.StringToEntries("[7,[6,[5,[7,0]]]]"));
            actual = JsonConvert.SerializeObject(Day18.ExplodeNumber(Day18.StringToEntries("[7,[6,[5,[4,[3,2]]]]]")));
            Assert.Equal(target, actual);

            target = JsonConvert.SerializeObject(Day18.StringToEntries("[[6,[5,[7,0]]],3]"));
            actual = JsonConvert.SerializeObject(Day18.ExplodeNumber(Day18.StringToEntries("[[6,[5,[4,[3,2]]]],1]")));
            Assert.Equal(target, actual);

            target = JsonConvert.SerializeObject(Day18.StringToEntries("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]"));
            actual = JsonConvert.SerializeObject(Day18.ExplodeNumber(Day18.StringToEntries("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]")));
            Assert.Equal(target, actual);

            target = JsonConvert.SerializeObject(Day18.StringToEntries("[[3,[2,[8,0]]],[9,[5,[7,0]]]]"));
            actual = JsonConvert.SerializeObject(Day18.ExplodeNumber(Day18.StringToEntries("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")));
            Assert.Equal(target, actual);
        }

        [Fact]
        public void SplitNumber()
        {
            var starter = (Day18.ExplodeNumber(Day18.StringToEntries("[[[[0,7],4],[7,[[8,4],9]]],[1,1]]")));
            var result = Day18.SplitNumber(starter);

            var target = JsonConvert.SerializeObject(Day18.StringToEntries("[[[[0,7],4],[[7,8],[0,[6,7]]]],[1,1]]"));
            var actual = JsonConvert.SerializeObject(Day18.SplitNumber(result));
            Assert.Equal(target, actual);
        }

        [Fact]
        public void ReduceNumber()
        {
            var target = JsonConvert.SerializeObject(Day18.StringToEntries("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]"));
            var actual = JsonConvert.SerializeObject(Day18.ReduceNumber(Day18.StringToEntries("[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]")));
            Assert.Equal(target, actual);
        }

        [Fact]
        public void AddNumbers()
        {
            Assert.Equal(JsonConvert.SerializeObject(Day18.StringToEntries("[[[[1,1],[2,2]],[3,3]],[4,4]]")), JsonConvert.SerializeObject(Day18.AddNumbers(_testInput1)));
            Assert.Equal(JsonConvert.SerializeObject(Day18.StringToEntries("[[[[3,0],[5,3]],[4,4]],[5,5]]")), JsonConvert.SerializeObject(Day18.AddNumbers(_testInput2)));
            Assert.Equal(JsonConvert.SerializeObject(Day18.StringToEntries("[[[[5,0],[7,4]],[5,5]],[6,6]]")), JsonConvert.SerializeObject(Day18.AddNumbers(_testInput3)));
            Assert.Equal(JsonConvert.SerializeObject(Day18.StringToEntries("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]")), JsonConvert.SerializeObject(Day18.AddNumbers(_testInput4)));
        }

        [Fact]
        public void GetMagnitude()
        {
            Assert.Equal(29, Day18.GetMagnitude(Day18.StringToEntries("[9,1]")));
            Assert.Equal(129, Day18.GetMagnitude(Day18.StringToEntries("[[9,1],[1,9]]")));
            Assert.Equal(143, Day18.GetMagnitude(Day18.StringToEntries("[[1,2],[[3,4],5]]")));
            Assert.Equal(1384, Day18.GetMagnitude(Day18.StringToEntries("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]")));
            Assert.Equal(791, Day18.GetMagnitude(Day18.StringToEntries("[[[[3,0],[5,3]],[4,4]],[5,5]]")));
            Assert.Equal(1137, Day18.GetMagnitude(Day18.StringToEntries("[[[[5,0],[7,4]],[5,5]],[6,6]]")));
            Assert.Equal(3488, Day18.GetMagnitude(Day18.StringToEntries("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]")));
        }

        IEnumerable<string> _testInput1 = @"[1,1]
[2,2]
[3,3]
[4,4]".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        IEnumerable<string> _testInput2 = @"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        IEnumerable<string> _testInput3 = @"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]
[6,6]".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        IEnumerable<string> _testInput4 = @"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]".Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
    }
}