namespace RoyalCode.Razor.Internal.Navigation;

internal static class PaginationWindowBuilder
{
    public static PaginationWindow Build(int currentPage, int totalPages, int windowSize)
    {
        var safeTotalPages = Math.Max(totalPages, 1);
        var safeCurrentPage = Math.Clamp(currentPage, 1, safeTotalPages);
        var safeWindowSize = Math.Max(windowSize, 1);

        if (safeTotalPages <= safeWindowSize)
        {
            return new PaginationWindow(
                Enumerable.Range(1, safeTotalPages).ToArray(),
                false,
                false);
        }

        var halfWindow = safeWindowSize / 2;
        var start = safeCurrentPage - halfWindow;
        var end = start + safeWindowSize - 1;

        if (start < 1)
        {
            start = 1;
            end = safeWindowSize;
        }

        if (end > safeTotalPages)
        {
            end = safeTotalPages;
            start = Math.Max(1, end - safeWindowSize + 1);
        }

        return new PaginationWindow(
            Enumerable.Range(start, end - start + 1).ToArray(),
            start > 1,
            end < safeTotalPages);
    }
}