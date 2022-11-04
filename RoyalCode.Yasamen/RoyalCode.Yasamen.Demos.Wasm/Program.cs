using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RoyalCode.Yasamen.Commons.Modules;
using RoyalCode.Yasamen.Demos.Wasm;
using RoyalCode.Yasamen.Demos.Wasm.Models;
using RoyalCode.Yasamen.Demos.Wasm.Shows;
using RoyalCode.Yasamen.Forms.Modules;
using RoyalCode.Yasamen.Icons;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// microsoft extensions
builder.Services.AddOptions();
builder.Services.AddLocalization();

// yasamen services
builder.Services.AddDataServices();
builder.Services.AddYasamenLocalization();

// yasamen js modules
builder.Services.AddScoped<CommonsJsModule>();
builder.Services.AddScoped<ScrollJsModule>();
builder.Services.AddScoped<ToggleJsModule>();
builder.Services.AddScoped<CssStyleJsModule>();
builder.Services.AddScoped<FormsJsModule>();

// App services.
builder.Services.Subscribes<DCService>();

// Show services
builder.Services.AddBlazorShow(b =>
{
    b.AddShow<IconShow, Icon>();
});

RoyalCode.Yasamen.Commons.Tracer.IsActive = true;
RoyalCode.Yasamen.Icons.Bootstrap.BootstrapIcons.Include();

await builder.Build().RunAsync();
