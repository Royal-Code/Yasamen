namespace System.Collections.Generic;

/// <summary>
/// Extension methods for collections.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Returns a slice of the given list starting at the specified index and of the specified length.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the list.</typeparam>
    /// <param name="list">The list to slice.</param>
    /// <param name="start">The starting index of the slice.</param>
    /// <param name="length">The length of the slice.</param>
    /// <returns>A slice of the list.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     If the start index or length is out of range.
    /// </exception>
    public static IEnumerable<T> Slice<T>(this IReadOnlyList<T> list, int start, int length)
    {
        ArgumentNullException.ThrowIfNull(list);

        if (start < 0 || start >= list.Count)
            throw new ArgumentOutOfRangeException(nameof(start));

        if (length < 0 || start + length > list.Count)
            throw new ArgumentOutOfRangeException(nameof(length));

        for (int i = start; i < start + length; i++)
        {
            yield return list[i];
        }
    }
}
