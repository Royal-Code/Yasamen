using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RoyalCode.Yasamen.Commons.Modules;
using RoyalCode.Yasamen.Forms.Modules;
using RoyalCode.Yasamen.Forms.Validation;
using RoyalCode.Yasamen.FormsSandBox.Wasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// yasamen js modules
builder.Services.AddScoped<CommonsJsModule>();
builder.Services.AddScoped<ScrollJsModule>();
builder.Services.AddScoped<ToggleJsModule>();
builder.Services.AddScoped<CssStyleJsModule>();
builder.Services.AddScoped<FormsJsModule>();
builder.Services.AddScoped<EventsJsModule>();

builder.Services.AddScoped<IValidatorProvider, ValidatorProvider>();

RoyalCode.Yasamen.Icons.Bootstrap.BootstrapIcons.Include();


await builder.Build().RunAsync();
