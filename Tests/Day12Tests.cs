using System.Collections.Generic;
using System.Linq;
using AdventOfCode1.Solutions;
using Xunit;

namespace Tests
{
    public class Day12Tests
    {
        private readonly IEnumerable<string[]> _input1;
        private readonly IEnumerable<string[]> _input2;
        private readonly IEnumerable<string[]> _input3;

        public Day12Tests()
        {
            _input1 = Day12.ParseInput(_inputString1);
            _input2 = Day12.ParseInput(_inputString2);
            _input3 = Day12.ParseInput(_inputString3);
        }

        [Fact]
        public void GetConnections()
        {
            var connections = Day12.GetConnections(_input1);
            Assert.Equal(6, connections.Count);
            Assert.Equal(2, connections["start"].Count);
            Assert.Contains("A", connections["start"]);
            Assert.Contains("b", connections["start"]);

            Assert.Equal(4, connections["A"].Count);
            Assert.Contains("b", connections["A"]);
            Assert.Contains("c", connections["A"]);   
            Assert.Contains("start", connections["A"]);
            Assert.Contains("end", connections["A"]);

            connections = Day12.GetConnections(_input2);
            Assert.Equal(4, connections["HN"].Count);
            Assert.Contains("start", connections["HN"]);
            Assert.Contains("dc", connections["HN"]);
            Assert.Contains("end", connections["HN"]);
            Assert.Contains("kj", connections["HN"]);
        }

        [Fact]
        public void GetNextSteps()
        {
            var currentPath = new List<string> { "start"};
            var connections = Day12.GetConnections(_input1);
            var steps = Day12.GetNextSteps(connections, currentPath)
                .ToList();
            Assert.Equal(2, steps.Count);
            Assert.Contains("A", steps);
            Assert.Contains("b", steps);

            currentPath.Add("A");

            steps = Day12.GetNextSteps(connections, currentPath)
                .ToList();
            Assert.Equal(3, steps.Count);
            Assert.Contains("b", steps);
            Assert.Contains("c", steps);
            Assert.Contains("end", steps);
        }

        [Fact]
        public void GetPathCount()
        {
            Assert.Equal(10, Day12.GetPathCount(_input1));
            Assert.Equal(19, Day12.GetPathCount(_input2));
            Assert.Equal(226, Day12.GetPathCount(_input3));
        }

        [Fact]
        public void GetNextStepsV2()
        {
            var currentPath = new List<string> { "start" };
            var connections = Day12.GetConnections(_input1);
            var steps = Day12.GetNextStepsV2(connections, currentPath)
                .ToList();
            Assert.Equal(2, steps.Count);
            Assert.Contains("A", steps);
            Assert.Contains("b", steps);

            currentPath.Add("A");

            steps = Day12.GetNextStepsV2(connections, currentPath)
                .ToList();
            Assert.Equal(3, steps.Count);
            Assert.Contains("b", steps);
            Assert.Contains("c", steps);
            Assert.Contains("end", steps);

            currentPath.Add("c");
            currentPath.Add("A");
            steps = Day12.GetNextStepsV2(connections, currentPath)
                .ToList();
            Assert.Equal(3, steps.Count);
            Assert.Contains("b", steps);
            Assert.Contains("c", steps);
            Assert.Contains("end", steps);

            currentPath.Add("c");
            currentPath.Add("A");
            steps = Day12.GetNextStepsV2(connections, currentPath)
                .ToList();
            Assert.Equal(2, steps.Count);
            Assert.Contains("b", steps);
            Assert.Contains("end", steps);
        }

        [Fact]
        public void GetPathCountV2()
        {
            Assert.Equal(36, Day12.GetPathCount(_input1, true));
            Assert.Equal(103, Day12.GetPathCount(_input2, true));
            Assert.Equal(3509, Day12.GetPathCount(_input3, true));
        }


        private const string _inputString1 = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

        private const string _inputString2 = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";

        private const string _inputString3 = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

    }
}