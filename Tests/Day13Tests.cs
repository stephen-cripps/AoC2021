using System.Collections.Generic;
using System.Linq;
using AdventOfCode1.Solutions;
using Xunit;

namespace Tests;

public class Day13Tests
{
    private IEnumerable<int[]> _dots;
    private IEnumerable<string[]> _folds;
    public Day13Tests()
    {
        (_dots, _folds) = Day13.ParseInput(Input);
    }

    [Fact]
    public void ApplyFold()
    {
        var result = Day13.ApplyFold(_dots.ToList(), _folds.ToArray()[0]);
        Assert.Equal(17, result.Count());

        result = Day13.ApplyFold(result.ToList(), _folds.ToArray()[1]);
        Assert.Equal(16, result.Count());
    }

    private const string Input = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";
}