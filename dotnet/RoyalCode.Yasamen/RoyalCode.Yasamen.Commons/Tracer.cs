using System.Runtime.CompilerServices;

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

    public static bool UseAllowedList;

    public static bool UseDeniedList;

    public readonly static ICollection<string> AllowedComponents = new List<string>();

    public readonly static ICollection<string> DeniedComponents = new List<string>();

    public static Action<string> OutputWriter = Console.WriteLine;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool CanWrite(string component)
    {
        if (!IsActive)
            return false;
        
        if (UseAllowedList)
            return AllowedComponents.Contains(component);

        if (UseDeniedList)
            return !DeniedComponents.Contains(component);

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(string component, string operation, string message)
    {
        if (CanWrite(component))
            OutputWriter($"{component} -> {operation}: {message}");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(string component, string operation, string format, params object[] args)
    {
        if (CanWrite(component))
            OutputWriter($"{component} -> {operation}: {string.Format(format, args)}");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write<TComponent>(string operation, string message)
        => Write(typeof(TComponent).Name, operation, message);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write<TComponent>(string operation, string format, params object[] args)
        => Write(typeof(TComponent).Name, operation, format, args);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Begin<TComponent>(string operation)
        => Write(typeof(TComponent).Name, operation, "Begin");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void End<TComponent>(string operation)
        => Write(typeof(TComponent).Name, operation, "End");
}