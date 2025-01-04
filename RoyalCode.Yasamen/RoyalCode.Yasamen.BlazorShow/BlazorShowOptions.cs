namespace RoyalCode.Yasamen.BlazorShow;

public class BlazorShowOptions
{
    public string Title { get; set; } = "Blazor Show";

    public string BaseRoute { get; set; } = "/show/";

    public string MakeRoute(string route) => BaseRoute + route;
}
