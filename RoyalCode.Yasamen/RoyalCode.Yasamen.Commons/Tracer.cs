namespace RoyalCode.Yasamen.Commons;

/// <summary>
/// Static class to log/trace events of components.
/// </summary>
public static class Tracer
{
    /// <summary>
    /// Active or deactive the trace.
    /// </summary>
    public static bool IsActive;

    public static bool UseWhiteList;

    public readonly static ICollection<string> AllowedComponents =new List<string>();

    public readonly static ICollection<string> DeniedComponents = new List<string>();

    public static void Write(string component, string operation, string message)
    {
        if (!IsActive)
            return;

        if (UseWhiteList && !AllowedComponents.Any(s => s == component))
            return;

        if (!UseWhiteList && DeniedComponents.Any(s => s == component))
            return;

        Console.WriteLine($"{component} -> {operation}: {message}");
    }

    public static void Write<TComponent>(string operation, string message)
        => Write(typeof(TComponent).Name, operation, message);

    public static void Begin<TComponent>(string operation)
        => Write(typeof(TComponent).Name, operation, "Begin");

    public static void End<TComponent>(string operation)
        => Write(typeof(TComponent).Name, operation, "End");
}