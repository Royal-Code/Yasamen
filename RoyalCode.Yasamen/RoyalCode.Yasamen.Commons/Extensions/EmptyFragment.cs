using Microsoft.AspNetCore.Components.Rendering;
using System.Reflection;

namespace Microsoft.AspNetCore.Components;

public static class EmptyFragment
{
    private static readonly MethodInfo EmptyFragmentMethod = typeof(EmptyFragment).GetMethod(nameof(EmptyRenderFragment))!;

    public static RenderFragment Delegate => EmptyRenderFragment;

    public static RenderFragment<TModel> GetDelegate<TModel>() => EmptyRenderFragment;

    private static void EmptyRenderFragment(RenderTreeBuilder builder) { }

    private static RenderFragment EmptyRenderFragment<TModel>(TModel model) => EmptyRenderFragment;

    public static bool IsNotEmptyFragment(this RenderFragment? fragment)
    {
        return fragment is not null && !Equate(fragment, Delegate);
    }
    
    public static bool IsNotEmptyFragment<T>(this RenderFragment<T>? fragment)
    {
        return fragment is not null && !Equate(fragment, GetDelegate<T>());
    }

    internal static bool Equate(Delegate a, Delegate b)
    {
        // remove delegate overhead
        while (a.Target is Delegate target)
            a = target;
        while (b.Target is Delegate target)
            b = target;

        // standard equality
        if (a == b)
            return true;

        // compiled method body
        if (a.Target != b.Target)
            return false;
        byte[] a_body = a.Method.GetMethodBody()!.GetILAsByteArray()!;
        byte[] b_body = b.Method.GetMethodBody()!.GetILAsByteArray()!;
        if (a_body.Length != b_body.Length)
            return false;
        for (int i = 0; i < a_body.Length; i++)
        {
            if (a_body[i] != b_body[i])
                return false;
        }
        return true;
    }
}