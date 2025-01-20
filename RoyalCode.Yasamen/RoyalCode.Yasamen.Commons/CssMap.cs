namespace RoyalCode.Yasamen.Commons;

/// <summary>
/// Função que contém as regras para criar as classes de um componente.
/// </summary>
/// <typeparam name="TComponent">O tipo do componente.</typeparam>
/// <param name="component">O componente.</param>
/// <returns>As classes CSS do componente.</returns>
public delegate string? CssMap<in TComponent>(TComponent component);