using AdventOfCode1.Extensions;

namespace AdventOfCode1.Solutions;

public class Day15
{
    public int[,] Input;

    public Day15(string input)
    {
        Input = input.ToMultiIntArray();
    }

    public int Solution1() => GetPathRisk();

    public long Solution2()
    {
        TileInput();
        return GetPathRisk();
    }

    public void TileInput()
    {
        var rows = Input.GetLength(0);
        var cols = Input.GetLength(1);
        var tiledInput = new int[rows * 5, cols * 5];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                for (var k = 0; k < 5; k++)
                {
                    for (var l = 0; l < 5; l++)
                    {
                        var value = Input[i, j] + k + l;

                        if (value > 9)
                            value -= 9;

                        tiledInput[i + rows * k, j + cols * l] = value;
                    }
                }
            }
        }

        Input = tiledInput;
    }

    public int GetPathRisk()
    {
        var positions = InitialisePositions();
        var potentialNodes = new Dictionary<(int row, int col), Position>() { { (0, 0), positions[(0, 0)] } };

        while (potentialNodes.Any())
        {
            var currentNode = potentialNodes
                .MinBy(p => p.Value.MinPathDistance)
                .Value;

            UpdateDistances(positions, currentNode, potentialNodes);
            currentNode.InTreeSet = true;

            potentialNodes.Remove((currentNode.Row, currentNode.Col));
        }

        return positions.Last().Value.MinPathDistance;
    }

    private void UpdateDistances(Dictionary<(int row, int col), Position> positions, Position currentPosition, Dictionary<(int row, int col), Position> potentialNodes)
    {
        var row = currentPosition.Row;
        var col = currentPosition.Col;

        var coords = new List<int[]> { new[] { row - 1, col }, new[] { row + 1, col }, new[] { row, col - 1 }, new[] { row, col + 1 } };

        foreach (var coord in coords)
        {
            if (positions.TryGetValue((coord[0], coord[1]), out var neighbour) && !neighbour.InTreeSet)
            {
                neighbour.MinPathDistance = Math.Min(neighbour.MinPathDistance, currentPosition.MinPathDistance + neighbour.StepValue);

                potentialNodes.TryAdd((coord[0], coord[1]), neighbour);
            }
        }
    }

    private Dictionary<(int row, int col), Position> InitialisePositions()
    {
        var rows = Input.GetLength(0);
        var cols = Input.GetLength(1);

        var positions = new Dictionary<(int row, int col), Position>();
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
                positions.Add((i, j), new Position
                {
                    Row = i,
                    Col = j,
                    MinPathDistance = int.MaxValue,
                    StepValue = Input[i, j]
                });
        }

        positions[(0, 0)].MinPathDistance = 0;

        return positions;
    }

    public class Position
    {
        public int Row;
        public int Col;
        public int MinPathDistance;
        public int StepValue;
        public bool InTreeSet;
    }
}
