using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RoyalCode.Razor.Docs.Client;
using RoyalCode.Razor.Icons.Bootstrap;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

BootstrapIcons.Include();

builder.Services.AddYasamenCommons();
builder.Services.AddYasamenModal();
builder.Services.AddYasamenOffCanvas();
builder.Services.AddYasamenMenu();

builder.Services.AddMenuItems();

await builder.Build().RunAsync();
