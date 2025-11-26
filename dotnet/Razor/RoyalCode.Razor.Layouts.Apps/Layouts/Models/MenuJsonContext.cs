using System.Text.Json.Serialization;

namespace RoyalCode.Razor.Layouts.Models;

/// <summary>
/// Serialization context for menu items.
/// </summary>
[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(MenuItem))]
[JsonSerializable(typeof(IReadOnlyList<MenuItem>))]
public partial class MenuJsonContext : JsonSerializerContext { }
