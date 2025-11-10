using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RoyalCode.Razor.Icons.Bootstrap;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

BootstrapIcons.Include();

builder.Services.AddYasamenCommons();
builder.Services.AddYasamenModal();

await builder.Build().RunAsync();
