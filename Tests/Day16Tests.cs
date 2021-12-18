using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode1.Extensions;
using AdventOfCode1.Solutions;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class Day16Tests
{

    public Day16Tests()
    {
    }

    [Fact]
    public void GetBinary()
    {
        Assert.Equal("110100101111111000101000", Day16.GetBinary("D2FE28"));
        Assert.Equal("00111000000000000110111101000101001010010001001000000000", Day16.GetBinary("38006F45291200"));
        Assert.Equal("11101110000000001101010000001100100000100011000001100000", Day16.GetBinary("EE00D40C823060"));
    }

    [Fact]
    public void ParseLiteral()
    {
        var day16 = new Day16();
        Assert.Equal((2021, 21), day16.ParseLiteral("110100101111111000101000"));
        Assert.Equal((10, 11), day16.ParseLiteral("11010001010"));
        Assert.Equal((20, 16), day16.ParseLiteral("0101001000100100"));
    }

    [Fact]
    public void ParseOperator()
    {
        var day16 = new Day16();
        Assert.Equal(27 + 22, day16.ParseOperator("00111000000000000110111101000101001010010001001000000000").length);
        Assert.Equal(18 + 33, day16.ParseOperator("11101110000000001101010000001100100000100011000001100000").length);
    }

    [Fact]
    public void ParsePacket()
    {
        var day16 = new Day16();
        day16.ParsePacket(Day16.GetBinary("8A004A801A8002F478"));
        Assert.Equal(16, day16.Versions.Sum());
        day16.Versions.Clear();

        day16.ParsePacket(Day16.GetBinary("620080001611562C8802118E34"));
        Assert.Equal(12, day16.Versions.Sum());
        day16.Versions.Clear();

        day16.ParsePacket(Day16.GetBinary("C0015000016115A2E0802F182340"));
        Assert.Equal(23, day16.Versions.Sum());
        day16.Versions.Clear();

        day16.ParsePacket(Day16.GetBinary("A0016C880162017C3686B18A3D4780"));
        Assert.Equal(31, day16.Versions.Sum());
        day16.Versions.Clear();
    }

    [Fact]
    public void ParsePacketV2()
    {
        var day16 = new Day16();
        Assert.Equal(3,day16.ParsePacket(Day16.GetBinary("C200B40A82")).value);
        Assert.Equal(54,day16.ParsePacket(Day16.GetBinary("04005AC33890")).value);
        Assert.Equal(7,day16.ParsePacket(Day16.GetBinary("880086C3E88112")).value);
        Assert.Equal(9,day16.ParsePacket(Day16.GetBinary("CE00C43D881120")).value);     
        Assert.Equal(1,day16.ParsePacket(Day16.GetBinary("D8005AC2A8F0")).value);
        Assert.Equal(0,day16.ParsePacket(Day16.GetBinary("F600BC2D8F")).value);
        Assert.Equal(0,day16.ParsePacket(Day16.GetBinary("9C005AC2F8F0")).value);
        Assert.Equal(1,day16.ParsePacket(Day16.GetBinary("9C0141080250320F1802104A08")).value);
    }
}