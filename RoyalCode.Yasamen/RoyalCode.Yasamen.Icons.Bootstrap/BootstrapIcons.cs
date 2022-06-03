using RoyalCode.Yasamen.Icons.Factory;

namespace RoyalCode.Yasamen.Icons.Bootstrap;

/// <summary>
/// Bootstrap icon configuration utility.
/// </summary>
public static class BootstrapIcons
{
    /// <summary>
    /// Incluí as opções e factory e ícones do Bootstrap.
    /// </summary>
    public static void Include()
    {
        IconContentFactories.AddIconContentFactory(typeof(BsIconNames), new BootstrapIconContentFactory());
    }
}
