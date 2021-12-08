using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode1.Extensions
{
    public static class NestedEnumerableExtension
    {
        public static T[,] ToMultiArray<T>(this IEnumerable<IEnumerable<T>> input)
        {
            var inputArr = input as IEnumerable<T>[] ?? input.ToArray();
            var length = inputArr[0].Count();
            var result = new T[inputArr.Length, length];
            for (var i = 0; i < inputArr.Length; i++)
            {
                var row = inputArr[i].ToArray();
                if (row.Length != length)
                {
                    throw new ArgumentException("Misaligned input");
                }

                for (var j = 0; j < length; j++)
                {
                    result[i, j] = row[j];
                }
            }

            return result;
        }
    }
}
