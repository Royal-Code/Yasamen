using RoyalCode.Razor.Components;
using RoyalCode.Razor.Internal.Navigation;
using RoyalCode.Razor.Styles;

namespace RoyalCode.Razor.Navigation.Tests;

public class PaginationTests
{
    [Fact]
    public void PaginationWindowBuilder_Should_Create_Window_At_Start()
    {
        var window = PaginationWindowBuilder.Build(currentPage: 1, totalPages: 10, windowSize: 7);

        Assert.Equal([1, 2, 3, 4, 5, 6, 7], window.Pages);
        Assert.False(window.ShowLeadingEllipsis);
        Assert.True(window.ShowTrailingEllipsis);
    }

    [Fact]
    public void PaginationWindowBuilder_Should_Create_Window_In_Middle()
    {
        var window = PaginationWindowBuilder.Build(currentPage: 5, totalPages: 10, windowSize: 7);

        Assert.Equal([2, 3, 4, 5, 6, 7, 8], window.Pages);
        Assert.True(window.ShowLeadingEllipsis);
        Assert.True(window.ShowTrailingEllipsis);
    }

    [Fact]
    public void PaginationWindowBuilder_Should_Create_Window_At_End()
    {
        var window = PaginationWindowBuilder.Build(currentPage: 10, totalPages: 10, windowSize: 7);

        Assert.Equal([4, 5, 6, 7, 8, 9, 10], window.Pages);
        Assert.True(window.ShowLeadingEllipsis);
        Assert.False(window.ShowTrailingEllipsis);
    }

    [Fact]
    public void Pagination_Should_Not_Render_When_There_Is_Only_One_Page()
    {
        using var ctx = new TestContext();

        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 1)
            .Add(p => p.TotalPages, 1));

        Assert.Equal(string.Empty, cut.Markup);
    }

    [Fact]
    public void Pagination_Should_Render_Controls_When_Configured_For_Single_Page()
    {
        using var ctx = new TestContext();

        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 1)
            .Add(p => p.TotalPages, 1)
            .Add(p => p.SinglePageMode, PaginationSinglePageMode.Render));

        Assert.NotNull(cut.Find("nav"));
        Assert.True(cut.Find("button[data-nav='first']").HasAttribute("disabled"));
        Assert.True(cut.Find("button[data-nav='last']").HasAttribute("disabled"));
    }

    [Fact]
    public void Pagination_Should_Render_Custom_Message_For_Single_Page_When_Configured()
    {
        using var ctx = new TestContext();

        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 1)
            .Add(p => p.TotalPages, 1)
            .Add(p => p.SinglePageMode, PaginationSinglePageMode.Message)
            .Add(p => p.SinglePageMessage, "Só existe uma página disponível."));

        Assert.Contains("Só existe uma página disponível.", cut.Markup);
        Assert.Empty(cut.FindAll("nav"));
    }

    [Fact]
    public void Pagination_Should_Invoke_OnPageChanged_For_Valid_Destination()
    {
        using var ctx = new TestContext();

        int? changedPage = null;

        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 4)
            .Add(p => p.TotalPages, 12)
            .Add(p => p.OnPageChanged, page => changedPage = page));

        cut.FindAll("button[data-nav='next']").First().Click();

        Assert.Equal(5, changedPage);
    }

    [Fact]
    public void Pagination_Should_Block_Interaction_During_Loading()
    {
        using var ctx = new TestContext();

        int? changedPage = null;

        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 4)
            .Add(p => p.TotalPages, 12)
            .Add(p => p.Loading, true)
            .Add(p => p.OnPageChanged, page => changedPage = page));

        var nextButton = cut.FindAll("button[data-nav='next']").First();

        Assert.True(nextButton.HasAttribute("disabled"));

        nextButton.Click();

        Assert.Null(changedPage);
    }

    [Fact]
    public void Pagination_Should_Disable_Border_Navigation_At_Bounds()
    {
        using var ctx = new TestContext();

        var firstPageCut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 1)
            .Add(p => p.TotalPages, 8));

        Assert.True(firstPageCut.Find("button[data-nav='first']").HasAttribute("disabled"));
        Assert.True(firstPageCut.FindAll("button[data-nav='previous']").First().HasAttribute("disabled"));

        var lastPageCut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 8)
            .Add(p => p.TotalPages, 8));

        Assert.True(lastPageCut.Find("button[data-nav='last']").HasAttribute("disabled"));
        Assert.True(lastPageCut.FindAll("button[data-nav='next']").First().HasAttribute("disabled"));
    }

    [Fact]
    public void Pagination_Should_Render_Aria_Current_And_Mobile_Summary()
    {
        using var ctx = new TestContext();

        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 4)
            .Add(p => p.TotalPages, 9));

        var nav = cut.Find("nav");
        var currentPageButton = cut.Find("button[data-page='4']");
        var mobileSummary = cut.Find(".ya-pagination-mobile-summary");

        Assert.Equal("Paginação", nav.GetAttribute("aria-label"));
        Assert.Equal("page", currentPageButton.GetAttribute("aria-current"));
        Assert.Contains("Página 4 de 9", mobileSummary.TextContent);
    }

    [Fact]
    public void Pagination_Should_Render_Icons_For_Navigation_Controls()
    {
        using var ctx = new TestContext();

        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 4)
            .Add(p => p.TotalPages, 9));

        Assert.NotNull(cut.Find("button[data-nav='first'] svg"));
        Assert.NotNull(cut.FindAll("button[data-nav='previous'] svg").First());
        Assert.NotNull(cut.FindAll("button[data-nav='next'] svg").First());
        Assert.NotNull(cut.Find("button[data-nav='last'] svg"));
    }

    [Fact]
    public void Pagination_Should_Use_Compact_Default_Size_Class()
    {
        using var ctx = new TestContext();

        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 2)
            .Add(p => p.TotalPages, 9));

        var nav = cut.Find("nav");

        Assert.Contains("ya-pagination-sm", nav.ClassList);
    }

    [Fact]
    public void Pagination_Should_Apply_Explicit_Size_Class()
    {
        using var ctx = new TestContext();

        var cut = ctx.RenderComponent<Pagination>(parameters => parameters
            .Add(p => p.CurrentPage, 2)
            .Add(p => p.TotalPages, 9)
            .Add(p => p.Size, Sizes.Large));

        var nav = cut.Find("nav");

        Assert.Contains("ya-pagination-lg", nav.ClassList);
    }
}