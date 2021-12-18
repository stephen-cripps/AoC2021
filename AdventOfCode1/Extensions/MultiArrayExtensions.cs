using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1.Extensions
{
    public static class MultiArrayExtensions
    {
        public static string ToPrintableString<T>(this T[,] matrix)
        {
            var output = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    output += matrix[i, j] + "\t";
                }
                output += Environment.NewLine;
            }

            return output;
        }
    }
}
