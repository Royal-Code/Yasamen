using System.Runtime.CompilerServices;

namespace RoyalCode.Razor.Commons;

/// <summary>
/// Static class to log/trace events of components.
/// </summary>
public static class Tracer
{
    /// <summary>
    /// Gets or sets a value indicating whether tracing is active.
    /// </summary>
    public static bool IsActive;

    /// <summary>
    /// Gets or sets a value indicating whether to use the allowed components list for filtering.
    /// </summary>
    public static bool UseAllowedList;

    /// <summary>
    /// Gets or sets a value indicating whether to use the denied components list for filtering.
    /// </summary>
    public static bool UseDeniedList;

    /// <summary>
    /// Gets the collection of allowed component names for tracing.
    /// </summary>
    public readonly static ICollection<string> AllowedComponents = [];

    /// <summary>
    /// Gets the collection of denied component names for tracing.
    /// </summary>
    public readonly static ICollection<string> DeniedComponents = [];

    /// <summary>
    /// Gets or sets the output writer action for trace messages.
    /// </summary>
    public static Action<string> OutputWriter = Console.WriteLine;

    public static void AllowComponent(string component)
    {
        IsActive = true;
        UseAllowedList = true;
        if (!AllowedComponents.Contains(component))
            AllowedComponents.Add(component);
    }

    public static void AllowComponent<TComponent>()
        => AllowComponent(typeof(TComponent).Name);

    public static void AllowComponents<TComponent1, TComponent2>()
    {
        AllowComponent<TComponent1>();
        AllowComponent<TComponent2>();
    }

    public static void AllowComponents<TComponent1, TComponent2, TComponent3>()
    {
        AllowComponent<TComponent1>();
        AllowComponent<TComponent2>();
        AllowComponent<TComponent3>();
    }

    public static void DenyComponent(string component)
    {
        IsActive = true;
        UseDeniedList = true;
        if (!DeniedComponents.Contains(component))
            DeniedComponents.Add(component);
    }

    public static void DenyComponent<TComponent>()
        => DenyComponent(typeof(TComponent).Name);

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

    /// <summary>
    /// Writes a trace message for the specified component and operation.
    /// </summary>
    /// <param name="component">The component name.</param>
    /// <param name="operation">The operation name.</param>
    /// <param name="message">The message to log.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(string component, string operation, string message)
    {
        if (CanWrite(component))
            OutputWriter($"{component} -> {operation}: {message}");
    }

    /// <summary>
    /// Writes a formatted trace message for the specified component and operation.
    /// </summary>
    /// <param name="component">The component name.</param>
    /// <param name="operation">The operation name.</param>
    /// <param name="template">The message template.</param>
    /// <param name="args">The arguments for the template.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write(string component, string operation, string template, params ReadOnlySpan<object?> args)
    {
        if (CanWrite(component))
            OutputWriter($"{component} -> {operation}: {string.Format(template, args)}");
    }

    /// <summary>
    /// Writes a trace message for the specified generic component type and operation.
    /// </summary>
    /// <typeparam name="TComponent">The component type.</typeparam>
    /// <param name="operation">The operation name.</param>
    /// <param name="message">The message to log.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write<TComponent>(string operation, string message)
        => Write(typeof(TComponent).Name, operation, message);

    /// <summary>
    /// Writes a formatted trace message for the specified generic component type and operation.
    /// </summary>
    /// <typeparam name="TComponent">The component type.</typeparam>
    /// <param name="operation">The operation name.</param>
    /// <param name="template">The message template.</param>
    /// <param name="args">The arguments for the template.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Write<TComponent>(string operation, string template, params ReadOnlySpan<object?> args)
        => Write(typeof(TComponent).Name, operation, template, args);

    /// <summary>
    /// Writes a trace message indicating the beginning of an operation for the specified generic component type.
    /// </summary>
    /// <typeparam name="TComponent">The component type.</typeparam>
    /// <param name="operation">The operation name.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Begin<TComponent>(string operation)
        => Write(typeof(TComponent).Name, operation, "Begin");

    /// <summary>
    /// Writes a trace message indicating the end of an operation for the specified generic component type.
    /// </summary>
    /// <typeparam name="TComponent">The component type.</typeparam>
    /// <param name="operation">The operation name.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void End<TComponent>(string operation)
        => Write(typeof(TComponent).Name, operation, "End");
}