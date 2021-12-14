using System.Collections.Generic;
using System.Linq;
using AdventOfCode1.Solutions;
using Xunit;

namespace Tests;

public class Day14Tests
{
    private string _polymer;
    private Dictionary<string, string> _insertions;

    public Day14Tests()
    {
        (_polymer, _insertions) = Day14.ParseInput(Input);
    }

    [Fact]
    public void GetCommonalityDiff()
    {
        Assert.Equal(1, Day14.GetCommonalityDiff(_polymer, _insertions, 1));
        Assert.Equal(1588, Day14.GetCommonalityDiff(_polymer, _insertions, 10));
    }

    private const string Input = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";
}