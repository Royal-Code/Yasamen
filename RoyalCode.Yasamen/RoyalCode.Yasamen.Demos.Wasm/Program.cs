using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RoyalCode.Yasamen.Animations;
using RoyalCode.Yasamen.Commons.Modules;
using RoyalCode.Yasamen.Components;
using RoyalCode.Yasamen.Demos.Wasm;
using RoyalCode.Yasamen.Demos.Wasm.Models;
using RoyalCode.Yasamen.Demos.Wasm.Shows.Components;
using RoyalCode.Yasamen.Demos.Wasm.Shows.Graphics;
using RoyalCode.Yasamen.Demos.Wasm.Shows.Layouts;
using RoyalCode.Yasamen.Forms.Modules;
using RoyalCode.Yasamen.Icons;
using RoyalCode.Yasamen.Layout;
using RoyalCode.Yasamen.Layout.Admin;

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
builder.Services.AddScoped<EventsJsModule>();

// App services.
builder.Services.Subscribes<DCService>();

// Show services
builder.Services.AddBlazorShow(b =>
{
    // graphics
    b.AddShow<IconShow, Icon>();
    b.AddShow<RotateShow, RotateAnimation>();
    // layouts
    b.AddShow<AppLayoutShow, AppLayout>();
    b.AddShow<BoxShow, Box>();
    b.AddShow<ArticleBoxShow, ArticleBox>();
    // components
    b.AddShow<AlertShow, Alert>();
    b.AddShow<WorkingAlertShow, WorkingAlert>();
    b.AddShow<ButtonShow, Button>();
});

RoyalCode.Yasamen.Commons.Tracer.IsActive = true;
RoyalCode.Yasamen.Icons.Bootstrap.BootstrapIcons.Include();

await builder.Build().RunAsync();
