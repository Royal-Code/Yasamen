using Microsoft.AspNetCore.Components;
using RoyalCode.Razor.Commons.Extensions;
using RoyalCode.Razor.Icons;
using RoyalCode.Razor.Internal.Navigation;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Components;

public partial class Pagination
{
    private static readonly Dictionary<string, object> iconAttributes = new()
    {
        ["aria-hidden"] = "true",
        ["focusable"] = "false",
    };

    private string? additionalAttributeClasses;
    private Dictionary<string, object>? unmatchedAttributes;
    private string navigationLabel = "Paginação";

    private int EffectiveTotalPages => Math.Max(TotalPages, 1);

    private int EffectiveCurrentPage => Math.Clamp(CurrentPage, 1, EffectiveTotalPages);

    private bool HasMultiplePages => TotalPages > 1;

    private bool ShouldRenderPagination => HasMultiplePages || SinglePageMode == PaginationSinglePageMode.Render;

    private bool ShouldRenderSinglePageMessage => !HasMultiplePages && SinglePageMode == PaginationSinglePageMode.Message;

    private bool IsFirstPage => EffectiveCurrentPage <= 1;

    private bool IsLastPage => EffectiveCurrentPage >= EffectiveTotalPages;

    private PaginationWindow Window => PaginationWindowBuilder.Build(EffectiveCurrentPage, EffectiveTotalPages, DesktopWindowSize);

    private string NavigationLabel => navigationLabel;

    private Dictionary<string, object>? UnmatchedAttributes => unmatchedAttributes;

    private string Classes => "ya-pagination"
        .AddClass(Size.ToPaginationSize())
        .AddClass(Loading, "ya-pagination-loading")
        .AddClass(additionalAttributeClasses)
        .AddClass(AdditionalClasses);

    private string MessageClasses => "ya-pagination ya-pagination-empty"
        .AddClass(Size.ToPaginationSize())
        .AddClass(additionalAttributeClasses)
        .AddClass(AdditionalClasses);

    private RenderFragment FirstIcon => WellKnownIcons.PaginationFirst("ya-pagination-icon", iconAttributes);

    private RenderFragment PreviousIcon => WellKnownIcons.PaginationPrevious("ya-pagination-icon", iconAttributes);

    private RenderFragment NextIcon => WellKnownIcons.PaginationNext("ya-pagination-icon", iconAttributes);

    private RenderFragment LastIcon => WellKnownIcons.PaginationLast("ya-pagination-icon", iconAttributes);

    [Parameter, EditorRequired]
    public int CurrentPage { get; set; }

    [Parameter, EditorRequired]
    public int TotalPages { get; set; }

    [Parameter]
    public int? PageSize { get; set; }

    [Parameter]
    public bool Loading { get; set; }

    [Parameter]
    public Sizes Size { get; set; }

    [Parameter]
    public PaginationSinglePageMode SinglePageMode { get; set; }

    [Parameter]
    public string SinglePageMessage { get; set; } = "Não há páginas suficientes para paginação.";

    [Parameter]
    public int DesktopWindowSize { get; set; } = 7;

    [Parameter]
    public EventCallback<int> OnPageChanged { get; set; }

    [Parameter]
    public string PreviousLabel { get; set; } = "Anterior";

    [Parameter]
    public string NextLabel { get; set; } = "Próxima";

    [Parameter]
    public string? AdditionalClasses { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? AdditionalAttributes { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        var clonedAttributes = AdditionalAttributes is null
            ? null
            : new Dictionary<string, object>(AdditionalAttributes);

        additionalAttributeClasses = clonedAttributes.ExtractClass();
        navigationLabel = clonedAttributes.Extract("aria-label", "Paginação");
        unmatchedAttributes = clonedAttributes is { Count: > 0 } ? clonedAttributes : null;
    }

    private async Task ChangePageAsync(int destinationPage)
    {
        if (Loading || destinationPage < 1 || destinationPage > EffectiveTotalPages || destinationPage == EffectiveCurrentPage)
            return;

        await OnPageChanged.InvokeAsync(destinationPage);
    }

    private bool IsInteractionDisabled(bool destinationUnavailable)
        => Loading || destinationUnavailable;

    private string GetControlClasses(bool destinationUnavailable)
        => "ya-pagination-link ya-pagination-control"
            .AddClass(IsInteractionDisabled(destinationUnavailable), "ya-pagination-link-disabled");

    private string GetPageClasses(int page)
        => "ya-pagination-link"
            .AddClass(page == EffectiveCurrentPage, "ya-pagination-link-active")
            .AddClass(IsInteractionDisabled(page == EffectiveCurrentPage), "ya-pagination-link-disabled");

    private string? GetAriaCurrent(int page)
        => page == EffectiveCurrentPage ? "page" : null;

    private static string GetPageLabel(int page)
        => $"Página {page}";
}