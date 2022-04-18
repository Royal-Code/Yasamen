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

    public static void Write(string component, string operation, string message)
    {
        if (!IsActive)
            return;
        
        Console.WriteLine($"{component} -> {operation}: {message}");
    }

    public static void Write<TComponent>(string operation, string message)
        => Write(typeof(TComponent).Name, operation, message);
}