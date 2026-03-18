namespace RoyalCode.Razor.Internal.Navigation;

internal sealed record PaginationWindow(
    IReadOnlyList<int> Pages,
    bool ShowLeadingEllipsis,
    bool ShowTrailingEllipsis);