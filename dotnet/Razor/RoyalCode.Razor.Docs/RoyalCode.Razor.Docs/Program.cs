using RoyalCode.Razor.Docs.Components;
using RoyalCode.Razor.Icons.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

BootstrapIcons.Include();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddYasamenCommons();
builder.Services.AddYasamenModal();
builder.Services.AddYasamenOffCanvas();
builder.Services.AddYasamenMenu();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(RoyalCode.Razor.Docs.Client._Imports).Assembly);

app.Run();
