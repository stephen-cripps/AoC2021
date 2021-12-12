namespace AdventOfCode1.Extensions
{
    public static class StringExtensions
    {
        public static int[,] ToMultiIntArray(this string input) => input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.ToArray().Select(c => (int)char.GetNumericValue(c)))
                .ToMultiArray();
    }
}
