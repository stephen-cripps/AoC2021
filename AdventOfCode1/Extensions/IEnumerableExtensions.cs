namespace AdventOfCode1.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool ContainsAll<T>(this IEnumerable<T> set, IEnumerable<T> subset) => subset.All(set.Contains);
    }
}
