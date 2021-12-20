using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode1.Extensions;
using AdventOfCode1.Solutions;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class Day17Tests
{

    public Day17Tests()
    {
    }

    [Fact]
    public void GetBestLaunchHeight()
    {
        Assert.Equal((45, 112), Day17.GetBestLaunchHeight(20, 30, -10, -5));
    }
}