using Microsoft.AspNetCore.Components;

namespace RoyalCode.Razor.Icons.Factory;


public delegate RenderFragment IconFragment(
    string? additionalClasses = null, 
    Dictionary<string, object>? additionalAttributes = null);
