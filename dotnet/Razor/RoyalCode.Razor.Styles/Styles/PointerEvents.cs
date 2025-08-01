namespace RoyalCode.Razor.Styles;

public enum PointerEvents
{
    Auto,
    None
}

public static class PointerEventsExtensions
{
    public static string ToCssClass(this PointerEvents pointerEvents)
    {
        return pointerEvents switch
        {
            PointerEvents.Auto => "pointer-events-auto",
            PointerEvents.None => "pointer-events-none",
            _ => throw new ArgumentOutOfRangeException(nameof(pointerEvents), pointerEvents, null)
        };
    }
}
