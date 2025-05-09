
using System.Diagnostics.CodeAnalysis;

namespace RoyalCode.Yasamen.Services.Infrastructure.Internal;

internal static class NamedLoaders
{
    private static readonly Dictionary<Key, Delegate> delegates = new();
    private static readonly Dictionary<Key, Type> serviceTypes = new();

    internal static void AddDelegate(string name, Type tmodel, Delegate @delegate)
    {
        var key = new Key(name, tmodel);
        delegates[key] = @delegate;
    }

    internal static void AddDelegate(string name, Type tmodel, Type tfilter, Delegate @delegate)
    {
        var key = new Key(name, tmodel, tfilter);
        delegates[key] = @delegate;
    }

    internal static void AddServiceType(string name, Type tmodel, Type serviceType)
    {
        var key = new Key(name, tmodel);
        serviceTypes[key] = serviceType;
    }

    internal static void AddServiceType(string name, Type tmodel, Type tfilter, Type serviceType)
    {
        var key = new Key(name, tmodel, tfilter);
        serviceTypes[key] = serviceType;
    }

    internal static Delegate? GetDelegate(string name, Type tmodel)
    {
        var key = new Key(name, tmodel);
        return delegates.TryGetValue(key, out var @delegate) ? @delegate : null;
    }

    internal static Delegate? GetDelegate(string name, Type tmodel, Type tfilter)
    {
        var key = new Key(name, tmodel, tfilter);
        return delegates.TryGetValue(key, out var @delegate) ? @delegate : null;
    }

    internal static Type? GetServiceType([NotNull]string name, Type tmodel)
    {
        var key = new Key(name, tmodel);
        return serviceTypes.TryGetValue(key, out var serviceType) ? serviceType : null;
    }

    internal static Type? GetServiceType([NotNull]string name, Type tmodel, Type tfilter)
    {
        var key = new Key(name, tmodel, tfilter);
        return serviceTypes.TryGetValue(key, out var serviceType) ? serviceType : null;
    }

    private record Key(string Name, Type Model, Type? Filter = null);
}

