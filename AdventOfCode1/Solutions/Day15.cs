using AdventOfCode1.Extensions;

namespace AdventOfCode1.Solutions;

public class Day15
{
    public int[,] Input;

    public Day15(string input)
    {
        Input = input.ToMultiIntArray();
    }

    //Possible Optimisations 
    // - Don't actually tile the input
    // - improve how we're finding the next node 
    // - Investigate A*

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
        var shortestPathTreeSet = new List<int>();
        var positions = InitialisePositions();

        var currentId = 0;

        while (shortestPathTreeSet.Count < positions.Count)
        {
            shortestPathTreeSet.Add(currentId);
            UpdateDistances(positions, currentId);

            if (shortestPathTreeSet.Count % 100 == 0)
                Console.WriteLine($"{shortestPathTreeSet.Count} of {positions.Count} nodes");

            currentId = positions
                .Where(p => !shortestPathTreeSet.Contains(p.Key))
                .OrderBy(p => p.Value.MinPathDistance)
                .FirstOrDefault()
                .Key;
        }

        var i = 0;
        foreach (var pos in positions)
        {
            Console.Write(pos.Value.MinPathDistance + "\t");

            if (i == 9)
            {
                Console.WriteLine();
                i = -1;
            }

            i++;
        }

        return positions.Last().Value.MinPathDistance;
    }

    private void UpdateDistances(Dictionary<int, Position> positions, int currentId)
    {
        var currentPosition = positions[currentId];
        var row = currentPosition.Row;
        var col = currentPosition.Col;

        if (positions.TryGetValue(GetId(row - 1, col), out var positionAbove))
        {
            positionAbove.MinPathDistance = Math.Min(positionAbove.MinPathDistance,
                currentPosition.MinPathDistance + positionAbove.StepValue);
        }

        if (positions.TryGetValue(GetId(row + 1, col), out var positionBelow))
        {
            positionBelow.MinPathDistance = Math.Min(positionBelow.MinPathDistance,
                currentPosition.MinPathDistance + positionBelow.StepValue);
        }

        if (col < Input.GetLength(1) - 1)
        {
            var positionRight = positions[GetId(row, col + 1)];
            positionRight.MinPathDistance = Math.Min(positionRight.MinPathDistance,
                currentPosition.MinPathDistance + positionRight.StepValue);
        }

        if (col > 0)
        {
            var positionLeft = positions[GetId(row, col - 1)];
            positionLeft.MinPathDistance = Math.Min(positionLeft.MinPathDistance,
                currentPosition.MinPathDistance + positionLeft.StepValue);
        }
    }

    private Dictionary<int, Position> InitialisePositions()
    {
        var rows = Input.GetLength(0);
        var cols = Input.GetLength(1);

        var positions = new Dictionary<int, Position>();
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
                positions.Add(GetId(i, j), new Position
                {
                    Row = i,
                    Col = j,
                    MinPathDistance = int.MaxValue,
                    StepValue = Input[i, j]
                });
        }

        positions[0].MinPathDistance = 0;

        return positions;
    }

    private int GetId(int row, int col) => row * Input.GetLength(0) + col;

    public class Position
    {
        public int Row;
        public int Col;
        public int MinPathDistance;
        public int StepValue;
    }
}
