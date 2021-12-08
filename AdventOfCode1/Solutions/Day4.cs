using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode1.Extensions;
using Newtonsoft.Json;

namespace AdventOfCode1.Solutions
{
    public class Day4
    {
        private const string NumberString = "27,14,70,7,85,66,65,57,68,23,33,78,4,84,25,18,43,71,76,61,34,82,93,74,26,15,83,64,2,35,19,97,32,47,6,51,99,20,77,75,56,73,80,86,55,36,13,95,52,63,79,72,9,10,16,8,69,11,50,54,81,22,45,1,12,88,44,17,62,0,96,94,31,90,39,92,37,40,5,98,24,38,46,21,30,49,41,87,91,60,48,29,59,89,3,42,58,53,67,28";

        private readonly IEnumerable<int[,]> _boards;
        private readonly IEnumerable<int> _numbers;

        public Day4()
        {
            _boards = ParseInput(File.ReadAllText("./Puzzle Inputs/Day4.txt"));
            _numbers = NumberString.Split(',')
                .Select(n => Convert.ToInt32(n));
        }
        public int Solution1()
        {//64084
            var (number, board, index) = GetWinningBoard(_numbers, _boards.ToArray());

            var sum = board.Cast<int>().Where(cell => cell > -1).Sum();

            return number * sum;
        }

        public int Solution2()
        {//12833
            var (number, board) = GetLosingBoard(_numbers, _boards);

            var sum = board.Cast<int>().Where(cell => cell > -1).Sum();

            return sum * number;
        }

        public (int, int[,]) GetLosingBoard(IEnumerable<int> numbers, IEnumerable<int[,]> boards)
        {
            var intsEnumerable = boards.ToList();
            while (intsEnumerable.Any())
            {
                var (number, board, index) = GetWinningBoard(numbers, intsEnumerable.ToArray());

                if (intsEnumerable.Count == 1)
                    return (number, intsEnumerable.Single());

                intsEnumerable = intsEnumerable.Where((board, i) => i != index).ToList();
            }

            throw new Exception("Losing board not found");
        }

        public int[][,] ParseInput(string input)
        {
            var paragraphMarker = Environment.NewLine + Environment.NewLine;
            var boardStrings = input.Split(new[] { paragraphMarker },
                StringSplitOptions.RemoveEmptyEntries).
                Select(s => s.Trim());

            return boardStrings.Select(s => s.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(row => row.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(cell => Convert.ToInt32(cell))).ToMultiArray())
                .ToArray();
        }

        public (int, int[,], int) GetWinningBoard(IEnumerable<int> numbers, int[][,] boards)
        {
            foreach (var number in numbers)
            {
                boards = MarkNumber(number, boards);

                var index = 0;
                foreach (var board in boards)
                {
                    if(CheckForBingo(board))
                        return (number, board, index);

                    index++;
                }
            }

            throw new Exception("Winning board not found"); 
        }

        private static int[][,] MarkNumber(int number, IEnumerable<int[,]> boards)
        {
            return boards.Select(board =>
            {
                for (var x = 0; x < board.GetLength(0); x++)
                {
                    for (var y = 0; y < board.GetLength(1); y ++)
                    {
                        if (board[x, y] == number) board[x, y] = -1;
                    }
                }
                return board;
            }).ToArray();
        }

        private static bool CheckForBingo(int[,] board)
        {
            for (var i = 0; i < board.GetLength(0); i++)
            {
                if(CheckLine(Enumerable.Range(0, board.GetLength(0)).Select(x => board[i,x])))
                    return true;
                if (CheckLine(Enumerable.Range(0, board.GetLength(1)).Select(x => board[x,i])))
                    return true;
            }

            return false;
        }

        private static bool CheckLine(IEnumerable<int>line) => line.All(cell => cell == -1);
    }
}